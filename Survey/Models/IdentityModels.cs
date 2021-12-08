using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Survey.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Class { get; set; }
        public string Specification { get; set; }
        public string Section { get; set; }
        public DateTime DateJoin { get; set; }
        public int Status { get; set; } //0.DEACTIVE 1.ACTIVE 2.DENY
        public virtual ICollection<AccountAnswer> AccountAnswers { get; set; }

       
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> Question_answers { get; set; }
        public DbSet<AccountAnswer> Account_answers { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<AllSurvey> Surveys { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}