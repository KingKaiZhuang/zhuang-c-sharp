using System;
using System.Collections.Generic;
using System.Windows;

namespace ClassLesson
{
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        Student selectedStudent = null;

        List<Course> courses = new List<Course>();

        List<Teacher> teachers = new List<Teacher>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeStudent();
            InitializeCourse();
        }

        private void InitializeCourse()
        {
            Teacher teacher1 = new Teacher()
            {
                TeacherName = "陳定宏"
            };
            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "視窗程式設計",
                OpeningClass = "四技二甲",
                Point = 3,
                Type = "必修"
            });

            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "資料結構",
                OpeningClass = "五專三甲",
                Point = 3,
                Type = "必修"
            });

            teacher1.TeachingCourses.Add(new Course(teacher1)
            {
                CourseName = "演算法設計",
                OpeningClass = "五專五甲",
                Point = 3,
                Type = "必修"
            });

        }

        private void InitializeStudent()
        {
            students.Add(new Student
            {
                StudentId = "A123456789",
                StudentName = "莊鈞凱"
            });
            students.Add(new Student
            {
                StudentId = "A123644354",
                StudentName = "許皓"
            });
            students.Add(new Student
            {
                StudentId = "A546456454",
                StudentName = "皓歌"
            });
            cmbStudent.ItemsSource = students;
        }

        private void cmbStudent_SelectionChanged(object sender, 
            System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            labelStatus.Content = selectedStudent.ToString();
        }
    }
}
