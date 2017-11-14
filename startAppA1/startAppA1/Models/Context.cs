using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace startAppA1.Models
{
    public class Context : IdentityDbContext<AppUser>
    {    
        public Context() : base("name=Context")
        {
        }

        public System.Data.Entity.DbSet<startAppA1.Models.Admin.AdminTableModel> AdminTableModels { get; set; }
        public System.Data.Entity.DbSet<startAppA1.Models.InstructorModel> InstructorModels { get; set; }
        public System.Data.Entity.DbSet<startAppA1.Models.StudentModel> StudentModels { get; set; }
        public System.Data.Entity.DbSet<startAppA1.Models.CourseModel> CourseModels { get; set; }
        public System.Data.Entity.DbSet<startAppA1.Models.GradeModel> GradeModels { get; set; }
        public System.Data.Entity.DbSet<startAppA1.Models.LessonModel> LessonModels { get; set; }
        public System.Data.Entity.DbSet<startAppA1.Models.WorkModel> WorkModels { get; set; }
        public DbSet<startAppA1.Models.LessonDataModel> LessonDataModels { get; set; }
        public DbSet<startAppA1.Models.AnswerModel> AnswerModels { get; set; }
        public DbSet<startAppA1.Models.QuestionstModel> QuestionModels { get; set; }

    }
}
