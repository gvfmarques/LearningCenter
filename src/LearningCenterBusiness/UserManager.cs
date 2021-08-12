using System;
using System.Collections.Generic;
using System.Text;
using LearningCenterRepository;

namespace LearningCenterBusiness
{
    public interface IUserManager
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password, ref bool isUserNameTaken);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserModel LogIn(string email, string password)
        {
            var user = userRepository.LogIn(email, password);

            if (user == null)
            {
                return null;
            }
            return new UserModel { Id = user.Id, Email = user.Email };
        }

        public UserModel Register(string email, string password, ref bool isUserNameTaken)
        {
            var user = userRepository.Register(email, password, ref isUserNameTaken);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Email = user.Email };
        }
    }
}
