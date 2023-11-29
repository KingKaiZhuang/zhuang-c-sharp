using System;

namespace ClassLesson
{
    class Course
    {
        public string CourseName { get; set; }
        public string Type {  get; set; }
        public int Point {  get; set; }
        public string OpeningClass {  get; set; }
        Teacher Tutor { get; set; }
        public Course(Teacher tutor)
        {
            Tutor = tutor;
        }
    }
}
