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

        public DbSet<Admin.AdminTableModel> AdminTableModels { get; set; }
        public DbSet<InstructorModel> InstructorModels { get; set; }
        public DbSet<StudentModel> StudentModels { get; set; }
        public DbSet<CourseModel> CourseModels { get; set; }
        public DbSet<GradeModel> GradeModels { get; set; }
        public DbSet<LessonModel> LessonModels { get; set; }
        public DbSet<WorkModel> WorkModels { get; set; }
        public DbSet<LessonDataModel> LessonDataModels { get; set; }
        public DbSet<AnswerModel> AnswerModels { get; set; }
        public DbSet<QuestionsModel> QuestionModels { get; set; }
        public DbSet<StringAnswerModel> StringAnswers { get; set; }
        public DbSet<StringQuestionModel> StringQuestions { get; set; }

        /// <summary>
        /// configures one-many and many-many relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new
            {
                r.RoleId,
                r.UserId
            });
            }
    }
}
