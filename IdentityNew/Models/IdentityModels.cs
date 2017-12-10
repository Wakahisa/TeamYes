using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityNew.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context()
            : base("Context", throwIfV1Schema: false)
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

        public static Context Create()
        {
            return new Context();
        }
    }
}