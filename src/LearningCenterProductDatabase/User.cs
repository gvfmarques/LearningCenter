using System;
using System.Collections.Generic;

namespace LearningCenterDatabase
{
    public partial class User
    {
        public User()
        {
            UserClass = new HashSet<UserClass>();
        }

        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public bool UserIsAdmin { get; set; }

        public ICollection<UserClass> UserClass { get; set; }
    }
}
