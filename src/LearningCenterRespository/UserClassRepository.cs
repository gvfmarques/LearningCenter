using System;
using System.Collections.Generic;
using System.Linq;

namespace LearningCenterRepository
{
    public class UserClassModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }
    }

    public interface IUserClassRepository
    {
        UserClassModel AddClass(int userId, int classId);
        UserClassModel[] GetEnrolledClasses(int userId);
        UserClassModel[] GetUnEnrolledClasses(int userId);
    }

    public class UserClassRepository : IUserClassRepository
    {
        public UserClassModel AddClass(int userId, int classId)
        {
            var item = DatabaseAccessor.Instance.UserClass.Add(
                new LearningCenterDatabase.UserClass
                {
                    ClassId = classId,
                    UserId = userId
                });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserClassModel
            {
                ClassId = item.Entity.ClassId,
                UserId = item.Entity.UserId
            };
        }

        public UserClassModel[] GetEnrolledClasses(int userId)
        {
            var items = DatabaseAccessor.Instance.UserClass
                .Where(t => t.UserId == userId)
                .Select(t => new UserClassModel
                {
                    UserId = userId,
                    ClassId = t.ClassId
                }).ToArray();

            return items;
        }

        public UserClassModel[] GetUnEnrolledClasses(int userId)
        {
            var enrolled = DatabaseAccessor.Instance.UserClass
                .Where(t => t.UserId == userId)
                .Select(t => t.ClassId).ToArray();

            var allClass = DatabaseAccessor.Instance.Class
                .Select(t => t.ClassId).ToArray();

            List<int> notEnrolled = new List<int>();

            foreach (int item in allClass)
            {
                if (!enrolled.Contains(item))
                {
                    notEnrolled.Add(item);
                }
            }

            var items = notEnrolled.Select(t => new UserClassModel { UserId = userId, ClassId = t }).ToArray();

            return items;
        }
    }
}
