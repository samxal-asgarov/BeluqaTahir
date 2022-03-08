using BeluqaTahir.Domain.Model.Entity;
using BeluqaTahir.Domain.Model.Entity.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeluqaTahir.Domain.Model.DataContexts
{
    public class BeluqaTahirDbContext : IdentityDbContext<BeluqaUser, BeluqaRole, int, BeluqaUserClaim, BeluqaUserRole, BeluqaUserLogin, BeluqaRoleClaim, BeluqaUserToken>
    {
        public BeluqaTahirDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Contact> contacts { get; set; }
        public DbSet<BlogPost> blogPosts { get; set; }
        public DbSet<ProductTypes> productTypes { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<HappyClients> happyClients { get; set; }
        public DbSet<AuditLog> auditLogs { get; set; }
        public DbSet<Accountdetails> accountdetails { get; set; }
        public DbSet<Subscrice> subscrices { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BeluqaUser>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("Users", "Membership");

            });

            builder.Entity<BeluqaRole>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("Roles", "Membership");

            });

            builder.Entity<BeluqaUserRole>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("UserRoles", "Membership");

            });

            builder.Entity<BeluqaUserClaim>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("UserClaims", "Membership");

            });

            builder.Entity<BeluqaRoleClaim>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("RoleClaims", "Membership");

            });
            builder.Entity<BeluqaUserToken>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("UserTokens", "Membership");

            });
            builder.Entity<BeluqaUserLogin>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("UserLogins", "Membership");

            });
        }
    }
}
