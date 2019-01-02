﻿using Amara.Solutions.Models;
using Amara.UserManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using UserManagement.Models;

namespace Amara.UserManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Read only parameter that makes use of dapper
        /// </summary>
        private readonly IReadOnlyRepository<User> _userRepository;
        public UserService(IUnitOfWork unitOfWork, IReadOnlyRepository<User> userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();
        }

        public IEnumerable<User> GetAllUser()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(string id)
        {
            return _userRepository.FindById(id);
        }

        public void UpdateUser(string id, User user)
        {
            throw new NotImplementedException();
        }
    }
}