﻿using System;

namespace ClassLesson
{
    internal class Student
    {
        public String StudentId { get; set; }
        public String StudentName { get; set; }
        public override string ToString()
        {
            return $"{StudentId} {StudentName}";
        }
    }
}