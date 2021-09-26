using SEDC.NotesApp.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        void AddUser(AddUpdateUserDto addUpdateUserDto);
        void UpdateUser(AddUpdateUserDto addUpdateUserDto);
        void DeleteUser(int id);
    }
}
