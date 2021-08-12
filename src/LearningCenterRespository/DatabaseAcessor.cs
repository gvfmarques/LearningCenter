using System;
using System.Collections.Generic;
using System.Text;

using LearningCenterDatabase;

namespace LearningCenterRepository
{
    class DatabaseAccessor
    {
        public static minicstructorContext Instance { get; private set; }

        static DatabaseAccessor()
        {
            Instance = new minicstructorContext();
        }
    }
}
