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

        //testing
        public DbSet<FooModel> FooModels { get; set; }
        public DbSet<BooModel> BooModels { get; set; }
        public DbSet<GooModel> GooModels { get; set; }

        /// <summary>
        /// configures one-many and many-many relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradeModel>()
                .HasRequired(c => c.Student)
                .WithMany(c => c.CourseGrade)
                .HasForeignKey(c => c.StudentID);

            modelBuilder.Entity<CourseModel>() // this is one of a set that
                .HasRequired(c => c.Instructor) // this has a lot of
                .WithMany(c => c.Courses) // it goes in this variable of it's holder
                .HasForeignKey(c => c.InstructorID); // and it IDs it holder as

            modelBuilder.Entity<LessonModel>() // this is one of a set that
                .HasRequired(c => c.Course) // this has a lot of
                .WithMany(c => c.Lessons) // it goes in this variable of it's holder
                .HasForeignKey(c => c.CourseID); // and it IDs it holder as

            modelBuilder.Entity<StringAnswerModel>() // this is one of a set that
                .HasRequired(c => c.AnswerModel) // this has a lot of
                .WithMany(c => c.Answers) // it goes in this variable of it's holder
                .HasForeignKey(c => c.AnswerModelID); // and it IDs it holder as

            modelBuilder.Entity<StringQuestionModel>() // this is one of a set that
                .HasRequired(c => c.QuestionModel) // this has a lot of
                .WithMany(c => c.Questions) // it goes in this variable of it's holder
                .HasForeignKey(c => c.QuestionModelID); // and it IDs it holder as


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
