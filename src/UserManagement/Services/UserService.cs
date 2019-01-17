using Amara.UserManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using UserManagement.Models;
using UserManagement.Repository.Dapper.Interface;
using UserManagement.Repository.EF.Interface;

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
            _unitOfWork.Users.Add(user);
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

        public bool UpdateUser(string id, User user)
        {
            user.Id = Guid.Parse(id);
            _unitOfWork.Users.Update(user);
            _unitOfWork.Save();

            return true;
        }
    }
}
