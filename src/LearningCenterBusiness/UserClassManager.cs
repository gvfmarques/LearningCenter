using System;
using System.Collections.Generic;
using System.Linq;
using LearningCenterRepository;

namespace LearningCenterBusiness
{
    public interface IUserClassManager
    {
        UserClassModel AddClass(int classId, int UserId);
        UserClassModel[] GetEnrolledClasses(int UserId);
        UserClassModel[] GetUnEnrolledClasses(int UserId);
    }

    public class UserClassModel
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }

    public class UserClassManager : IUserClassManager
    {
        private readonly IUserClassRepository userClassRepository;
        private readonly IClassRepository classRepository;

        public UserClassManager(IUserClassRepository userClassRepository, IClassRepository classRepository)
        {
            this.userClassRepository = userClassRepository;
            this.classRepository = classRepository;
        }

        public UserClassModel AddClass(int classId, int userId)
        {
            var item = userClassRepository.AddClass(userId, classId);

            return new UserClassModel
            {
                UserId = item.UserId,
                ClassId = item.ClassId
            };
        }

        public UserClassModel[] GetEnrolledClasses(int userId)
        {
            var items = getUserClassesHelper(userClassRepository.GetEnrolledClasses(userId));

            return items;
        }

        public UserClassModel[] GetUnEnrolledClasses(int userId)
        {
            var items = getUserClassesHelper(userClassRepository.GetUnEnrolledClasses(userId));

            return items;
        }

        private UserClassModel[] getUserClassesHelper(LearningCenterRepository.UserClassModel[] list)
        {
            var items = list
                .Select(t =>
                {
                    var cls = getClassDetails(t.ClassId);

                    return new UserClassModel
                    {
                        ClassId = cls.ClassId,
                        ClassName = cls.ClassName,
                        ClassDescription = cls.ClassDescription,
                        ClassPrice = cls.ClassPrice
                    };
                }).ToArray();

            return items;
        }

        private ClassModel getClassDetails(int classId)
        {
            var item = classRepository.GetClass(classId);

            return new ClassModel(item.ClassId, item.ClassName, item.ClassDescription, item.ClassPrice);
        }
    }
}
