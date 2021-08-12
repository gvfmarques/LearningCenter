using System;
using System.Linq;
using LearningCenterRepository;

namespace LearningCenterBusiness
{
    public interface IClassManager
    {
        ClassModel[] Classes { get; }
        ClassModel Class(int classId);
        ClassModel GetClass(int classId);
    }

    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }

        public ClassModel(int classId, string className, string classDescription, decimal classPrice)
        {
            ClassId = classId;
            ClassName = className;
            ClassDescription = classDescription;
            ClassPrice = classPrice;
        }
    }

    public class ClassManager : IClassManager
    {
        private readonly IClassRepository classRepository;

        public ClassManager(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public ClassModel[] Classes
        {
            get
            {
                return classRepository.Classes
                    .Select(t => new ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice))
                    .ToArray();
            }
        }

        public ClassModel Class(int classId)
        {
            var ClassModel = classRepository.Class(classId);

            return new ClassModel(ClassModel.ClassId, ClassModel.ClassName, ClassModel.ClassDescription, ClassModel.ClassPrice);
        }

        public ClassModel GetClass(int classId)
        {
            var ClassModel = classRepository.Class(classId);

            return new ClassModel(ClassModel.ClassId, ClassModel.ClassName, ClassModel.ClassDescription, ClassModel.ClassPrice);
        }
    }
}
