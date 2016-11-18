using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GotFood.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
       [ForeignKey("IdentityUser")]
        public virtual DbSet<IdentityUserRole> Roles { get; set; }
        [Key]
        public virtual DbSet<IdentityUserLogin> Logins { get; set; }

        public virtual ICollection<Provider> Providers { get; set; }
        //public virtual ICollection<CharityProfile> CharityProfiles { get; set; }
        //public virtual ICollection<Transport> Transports { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            
            return new ApplicationDbContext();
        }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //public DbSet<Provider> Providers { get; set; }
        //public DbSet<Transport> Transports { get; set; }
        //public DbSet<CharityProfile> CharityProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ApplicationUser>();
            //modelBuilder.Entity<IdentityUserLogin>();/*.HasKey<string>(l => l.UserId);*/
            //modelBuilder.Entity<IdentityRole>();/*.HasKey<string>(r => r.Id);*/
            //modelBuilder.Entity<IdentityUserRole>();/*.HasKey(r => new { r.RoleId, r.UserId });*/
            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("AspNetUserRoles");

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("AspNetUserLogins");

            modelBuilder.Entity<IdentityRole>()
                .HasKey(r => r.Id)
                .ToTable("AspNetRoles");
        }


        //public virtual ICollection<Provider> Providers { get; set; }
        //public virtual ICollection<CharityProfile> CharityProfiles { get; set; }
        //public virtual ICollection<Transport> Transports { get; set; }

        //public System.Data.Entity.DbSet<GotFood.Models.CharityProfile> CharityProfiles { get; set; }
        public System.Data.Entity.DbSet<GotFood.Models.Provider> Providers { get; set; }
        //public System.Data.Entity.DbSet<GotFood.Models.Transport> Transports { get; set; }
        
    }
}