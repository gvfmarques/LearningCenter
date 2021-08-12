using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LearningCenterWebsite.Models
{
    public class UserClassModel
    {
        public int UserId { get; set; }

        public ClassModel MyClassModel { get; set; }
    }
}
