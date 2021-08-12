using System.Linq;

namespace LearningCenterRepository
{
    public interface IUserRepository
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password, ref bool isUserNameTaken);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }

    public class UserRepository : IUserRepository
    {
        public UserModel LogIn(string email, string password)
        {
            var user = DatabaseAccessor.Instance.User
                .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower()
                && t.UserPassword == password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.UserId, Email = user.UserEmail };
        }

        public UserModel Register(string email, string password, ref bool isUserNameTaken)
        {
            if (!isUserNameExisting(email))
            {
                var user = DatabaseAccessor.Instance.User
                    .Add(new LearningCenterDatabase.User
                    {
                        UserEmail = email,
                        UserPassword = password
                    });

                DatabaseAccessor.Instance.SaveChanges();

                isUserNameTaken = false;

                return new UserModel { Id = user.Entity.UserId, Email = user.Entity.UserEmail };
            }
            else
            {
                isUserNameTaken = true;
            }

            return null;
        }

        private bool isUserNameExisting(string email)
        {
            var user = DatabaseAccessor.Instance.User.Where(c => c.UserEmail == email).FirstOrDefault();

            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
