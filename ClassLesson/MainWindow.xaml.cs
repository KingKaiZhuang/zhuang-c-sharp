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

            Teacher teacher2 = new Teacher() { TeacherName = "陳福坤" };
            teacher2.TeachingCourses.Add(new Course(teacher2)
            {
                CourseName = "計算機概論",
                OpeningClass = "四技一丙",
                Point = 2,
                Type = "必修"
            });
            teacher2.TeachingCourses.Add(new Course(teacher2)
            {
                CourseName = "計算機概論",
                OpeningClass = "四技一甲一乙",
                Point = 2,
                Type = "必修"
            });

            Teacher teacher3 = new Teacher() { TeacherName = "許子衡" };
            teacher3.TeachingCourses.Add(new Course(teacher3)
            {
                CourseName = "Android程式設計",
                OpeningClass = "四技一甲一乙",
                Point = 3,
                Type = "選修"
            });
            teacher3.TeachingCourses.Add(new Course(teacher3)
            {
                CourseName = "人工智慧與雲端運算",
                OpeningClass = "五專資工三甲",
                Point = 3,
                Type = "必修"
            });

            teachers.Add(teacher1);
            teachers.Add(teacher2);
            teachers.Add(teacher3);

            tvTeacher.ItemsSource = teachers;
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
