using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ElearningWebsite.Authorization.Roles;
using ElearningWebsite.Authorization.Users;
using ElearningWebsite.MultiTenancy;
using ElearningWebsite.Entities;

namespace ElearningWebsite.EntityFrameworkCore
{
    public class ElearningWebsiteDbContext : AbpZeroDbContext<Tenant, Role, User, ElearningWebsiteDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Course>  Courses { get; set; }
        public DbSet<TypeOfCourse> TypeOfCourses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public ElearningWebsiteDbContext(DbContextOptions<ElearningWebsiteDbContext> options)
            : base(options)
        {
        }
    }
}
