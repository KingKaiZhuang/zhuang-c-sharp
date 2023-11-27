using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLesson
{
    internal class Teacher
    {
        public String TeacherName { get; set; }
        public ObservableCollection<Course> TeachingCourses { get; set; } = new
            ObservableCollection<Course>();
    }
}
