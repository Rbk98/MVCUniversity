using System.Globalization;
public static class SeedData
{
    public static void Initialiser()
    {
        using (var context = new MvcUniversityContext())
        {

            // Add students
            Student carson = new Student
            {
                FirstName = "Alexander",
                LastName = "Carson",
                EnrollmentDate = DateTime.Parse("2016-09-01"),
            };
            Student alonso = new Student
            {
                FirstName = "Meredith",
                LastName = "Alonso",
                EnrollmentDate = DateTime.Parse("2018-09-01"),
            };
            Student anand = new Student
            {
                FirstName = "Arturo",
                LastName = "Anand",
                EnrollmentDate = DateTime.Parse("2019-09-01"),
            };
            Student barzdukas = new Student
            {
                FirstName = "Gytis",
                LastName = "Barzdukas",
                EnrollmentDate = DateTime.Parse("2018-09-01"),
            };
            context.Students.AddRange(
                carson,
                alonso,
                anand,
                barzdukas
            );

            // Add courses
            Course chemistry = new Course
            {
                Id = 1050,
                Title = "Chemistry",
                Credits = 3
            };
            Course microeconomics = new Course
            {
                Id = 4022,
                Title = "Microeconomics",
                Credits = 3
            };
            Course macroeconmics = new Course
            {
                Id = 4041,
                Title = "Macroeconomics",
                Credits = 3
            };
            Course calculus = new Course
            {
                Id = 1045,
                Title = "Calculus",
                Credits = 4
            };
            context.Courses.AddRange(
                chemistry,
                microeconomics,
                macroeconmics,
                calculus
            );

            // Add enrollments
            context.Enrollments.AddRange(
                new Enrollment
                {
                    Student = carson,
                    Course = chemistry,
                    Grade = Grade.A
                },
                new Enrollment
                {
                    Student = carson,
                    Course = microeconomics,
                    Grade = Grade.C
                },
                new Enrollment
                {
                    Student = alonso,
                    Course = calculus,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    Student = anand,
                    Course = chemistry,
                },
                new Enrollment
                {
                    Student = anand,
                    Course = microeconomics,
                    Grade = Grade.B
                },
                new Enrollment
                {
                    Student = barzdukas,
                    Course = chemistry,
                    Grade = Grade.C
                }
            );

            context.SaveChanges();
        }
    }
}