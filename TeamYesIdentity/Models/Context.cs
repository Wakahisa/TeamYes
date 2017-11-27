using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TeamYesIdentity.Models
{
    public class Context : IdentityDbContext<AppUser>
    {    
        public Context() : base("name=Context")
        {
        }

        public System.Data.Entity.DbSet<TeamYesIdentity.Models.Admin.AdminTableModel> AdminTableModels { get; set; }
        public System.Data.Entity.DbSet<TeamYesIdentity.Models.InstructorModel> InstructorModels { get; set; }
        public System.Data.Entity.DbSet<TeamYesIdentity.Models.StudentModel> StudentModels { get; set; }
        public System.Data.Entity.DbSet<TeamYesIdentity.Models.CourseModel> CourseModels { get; set; }
        public System.Data.Entity.DbSet<TeamYesIdentity.Models.GradeModel> GradeModels { get; set; }
        public System.Data.Entity.DbSet<TeamYesIdentity.Models.LessonModel> LessonModels { get; set; }
        public System.Data.Entity.DbSet<TeamYesIdentity.Models.WorkModel> WorkModels { get; set; }
        public DbSet<TeamYesIdentity.Models.LessonDataModel> LessonDataModels { get; set; }
        public DbSet<TeamYesIdentity.Models.AnswerModel> AnswerModels { get; set; }
        public DbSet<TeamYesIdentity.Models.QuestionstModel> QuestionModels { get; set; }

    }
}
