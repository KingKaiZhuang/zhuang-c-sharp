using System;
using System.Collections.ObjectModel;

namespace ClassLesson
{
    internal class Teacher
    {
        public String? TeacherName { get; set; }
        public ObservableCollection<Course> TeachingCourses { get; set; } = new ObservableCollection<Course>();

        public override string ToString()
        {
            return $"{TeacherName}";
        }
    }
}