using System;
using System.Collections.Generic;

public class Department
{
    public int Id { get; set; }

    public String Name { get; set; }

    public int InstructorId { get; set; }

    public Instructor Administrator { get; set; }

    public ICollection<Course> Courses { get; set; }
}