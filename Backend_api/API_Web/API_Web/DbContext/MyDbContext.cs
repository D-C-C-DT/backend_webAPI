using API_Web.Data;
using API_Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace API_Web.DbContext
{
    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        #region DbSet
        public DbSet<Khoa_Hoc> Khoa_Hocs { get; set; }
        public DbSet<Danh_Muc> Danh_Muc { get; set; }
        public DbSet<Chuong> Chuongs { get; set; }
        public DbSet<User_KhoaHoc> User_KhoaHocs { get; set; }
        public DbSet<Bai_Hoc> Bai_Hocs { get; set; }


        #endregion
        #region Configure Fluent API
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            #region  Configure a unique name for the entity

            Builder.Entity<Khoa_Hoc>().HasIndex(p => p.Ten_Khoa_Hoc).IsUnique();
            Builder.Entity<Danh_Muc>().HasIndex(p => p.Ten_DM).IsUnique();
            Builder.Entity<Chuong>().HasIndex(p => p.Name).IsUnique();

            #endregion
            #region Configure the relationship between Chuong and Khoa_Hoc
            Builder.Entity<Chuong>()
                .HasOne(c => c.Khoa_hocs)
                .WithMany(p => p.Chuongs)
                .HasForeignKey(p => p.Id_KH)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Configure a reltionship of User_Khoa_hoc
            Builder.Entity<User_KhoaHoc>()
                .HasKey(uc => new { uc.UserId, uc.ID_KH });
            Builder.Entity<User_KhoaHoc>()
               .HasOne(uc => uc.User)
               .WithMany(u => u.User_KhoaHocs)
               .HasForeignKey(uc => uc.UserId);

            Builder.Entity<User_KhoaHoc>()
                .HasOne(uc => uc.Khoa_Hocs)
                .WithMany(c => c.User_KhoaHocs)
                .HasForeignKey(uc => uc.ID_KH);
            #endregion

            #region Configure the relationship between Chapter and Lesson
            Builder.Entity<Bai_Hoc>()
            .HasOne(l => l.Chuong)
            .WithMany(c => c.Bai_Hocs)
            .HasForeignKey(l => l.Id_Chuong)
            .OnDelete(DeleteBehavior.Cascade);

            #endregion



        }
        #endregion
    }
}