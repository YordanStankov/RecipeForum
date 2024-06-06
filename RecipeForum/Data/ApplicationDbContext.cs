using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeForum.Models;

namespace RecipeForum.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Upvote> Upvotes { get; set;}
        public override DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Comment>(c =>
            {
                c.HasOne(x => x.Recipe).WithMany(r => r.Comments).OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Upvote>(c => {
                c.HasKey(x => new { x.UserId, x.RecipeId });

                c.HasOne(u => u.User)
                  .WithMany(u => u.Upvotes)
                  .HasForeignKey(u => u.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

                c.HasOne(u => u.Recipe)
                    .WithMany(fm => fm.Upvotes)
                    .HasForeignKey(u => u.RecipeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
        }

    }
}
