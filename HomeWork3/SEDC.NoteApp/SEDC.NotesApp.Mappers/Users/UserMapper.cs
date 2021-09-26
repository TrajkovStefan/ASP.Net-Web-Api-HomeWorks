using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Mappers.Users
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Age = user.Age
            };
        }
        public static User ToUser(this AddUpdateUserDto addUpdateUserDto)
        {
            return new User
            {
                FirstName = addUpdateUserDto.FirstName,
                LastName = addUpdateUserDto.LastName,
                UserName = addUpdateUserDto.UserName,
                Age = addUpdateUserDto.Age
            };
        }
    }  
}
