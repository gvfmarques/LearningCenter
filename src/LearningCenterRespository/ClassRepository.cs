using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LearningCenterRepository
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }

    public interface IClassRepository
    {
        ClassModel[] Classes { get; }
        ClassModel Class(int ClassId);
        ClassModel GetClass(int classId);
    }

    public class ClassRepository : IClassRepository
    {
        public ClassModel[] Classes
        {
            get
            {
                return DatabaseAccessor.Instance.Class
                    .Select(t => new ClassModel { ClassId = t.ClassId, ClassName = t.ClassName, ClassDescription = t.ClassDescription, ClassPrice = t.ClassPrice })
                    .ToArray();
            }
        }

        public ClassModel Class(int ClassId)
        {
            var Class = DatabaseAccessor.Instance.Class
                                                   .Where(t => t.ClassId == ClassId)
                                                   .Select(t => new ClassModel { ClassId = t.ClassId, ClassName = t.ClassName })
                                                   .First();
            return Class;
        }

        public ClassModel GetClass(int classId)
        {
            var _class = DatabaseAccessor.Instance.Class
                .Where(t => t.ClassId == classId)
                .Select(t => new ClassModel { ClassId = t.ClassId, ClassName = t.ClassName, ClassDescription = t.ClassDescription, ClassPrice = t.ClassPrice })
                .First();

            return _class;
        }
    }
}
