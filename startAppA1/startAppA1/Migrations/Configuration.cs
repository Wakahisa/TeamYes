namespace startAppA1.Migrations
{
    using startAppA1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<startAppA1.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(startAppA1.Models.Context context)
        {
            context.StudentModels.Add(new StudentModel
            {
                ID = 1,
                StudentID = 100,
                FirstName = "Amy",
                LastName = "Addams",
                MiddleInital = "A",
                EmailAddress = "A@uaa.edu"
            });
            context.StudentModels.Add(new StudentModel
            {
                ID = 2,
                StudentID = 101,
                FirstName = "Bob",
                LastName = "Badger",
                MiddleInital = "B",
                EmailAddress = "B@uaa.edu"
            });
            context.InstructorModels.Add(new InstructorModel
            {
                ID = 1,
                IsAdmin = true,
                FirstName = "Carl",
                LastName = "Carpenter",
                MiddleInital = "C",
            });
            context.InstructorModels.Add(new InstructorModel
            {
                ID = 2,
                IsAdmin = false,
                FirstName = "Donna",
                LastName = "Dorisdotter",
                MiddleInital = "D",
            });

        }
    }
}
