﻿using Catalog_Online.Models.Dtos;
using Catalog_Online.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Catalog_Online.Services
{
    public interface IUserService
    {
        public User RegisterUser(User user);

        public User GetUserById(int id);

        public User UpdateUserData(User newUserData, int id);

        public User DeleteUserData( int id);

        public List<User> GetAllUsers();

        public List<StudentUserListing> GetAllStudentUsersData();

        public List<UserRolDto> GetAllUserData();

        public User GetUserByEmail(string email);

        public bool CheckPassword(User user, string password);

        public Role GetUserRole(User user);

        public List<User> GetTeachers();

    }
}
