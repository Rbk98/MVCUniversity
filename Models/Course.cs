using System;
using System.Collections.Generic;

namespace EFUniversity
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public List<Enrollment> Enrollments { get; set; }

        public override string ToString()
        {
            return "Course n°:" + Id + ", title: " + Title + " , Credits: " + Credits;
        }
    }
}