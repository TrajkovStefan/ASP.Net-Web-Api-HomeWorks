using SEDC.NotesApp.DataAccess.Interfaces;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Dtos.Users;
using SEDC.NotesApp.Mappers.Users;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NotesApp.Services.Implementations
{
    public class UsersService : IUserService
    {
        private IRepository<User> _usersRepository;
        private IRepository<Note> _notesRepository;
        public UsersService(IRepository<User> usersRepository, IRepository<Note> notesRepository)
        {
            _usersRepository = usersRepository;
            _notesRepository = notesRepository;
        }
        public void AddUser(AddUpdateUserDto addUpdateUserDto)
        {
            ValidateUserInput(addUpdateUserDto);

            User newUser = addUpdateUserDto.ToUser();
            _usersRepository.Insert(newUser);
        }

        public void DeleteUser(int id)
        {
            User userDb = _usersRepository.GetById(id);
            if(userDb == null)
            {
                throw new ResourceNotFoundException(id, $"User with id {id} was not found!");
            }
            _usersRepository.Delete(userDb);
        }

        public List<UserDto> GetAllUsers()
        {
            List<User> usersDb = _usersRepository.GetAll();
            return usersDb.Select(x => x.ToUserDto()).ToList();
        }

        public UserDto GetUserById(int id)
        {
            User userDb = _usersRepository.GetById(id);
            if(userDb == null)
            {
                throw new ResourceNotFoundException(id, $"User with id {id} was not found!");
            }
            return userDb.ToUserDto();
        }

        public void UpdateUser(AddUpdateUserDto addUpdateUserDto)
        {
            User userDb = _usersRepository.GetById(addUpdateUserDto.Id);
            if (userDb == null)
            {
                throw new ResourceNotFoundException(addUpdateUserDto.Id, $"User with id {addUpdateUserDto.Id} was not found");
            }
            ValidateUserInput(addUpdateUserDto);
            userDb.FirstName = addUpdateUserDto.FirstName;
            userDb.LastName = addUpdateUserDto.LastName;
            userDb.UserName = addUpdateUserDto.UserName;
            userDb.Age = addUpdateUserDto.Age;

            _usersRepository.Update(userDb);
        }

        #region private methods
        private void ValidateUserInput(AddUpdateUserDto addUpdateUserDto)
        {
            User userDb = _usersRepository.GetById(addUpdateUserDto.Id);
            if (userDb == null)
            {
                throw new UserException("The user does not exists!");
            }
            if (string.IsNullOrEmpty(addUpdateUserDto.FirstName))
            {
                throw new UserException("The firstname must not be empty!");
            }
            if (addUpdateUserDto.FirstName.Length > 50)
            {
                throw new UserException("The firstname should not contain more than 50 characters!");
            }
            if (string.IsNullOrEmpty(addUpdateUserDto.LastName))
            {
                throw new UserException("The lastname must not be empty!");
            }
            if (addUpdateUserDto.LastName.Length > 50)
            {
                throw new UserException("The lastname should not contain more than 50 characters!");
            }
            if (string.IsNullOrEmpty(addUpdateUserDto.UserName))
            {
                throw new UserException("The username must not be empty!");
            }
            if (addUpdateUserDto.UserName.Length > 30)
            {
                throw new UserException("The username should not contain more than 30 characters!");
            }
            if (addUpdateUserDto.Age < 0)
            {
                throw new UserException("The age can not be less than zero!");
            }
        }
        #endregion
    }
}