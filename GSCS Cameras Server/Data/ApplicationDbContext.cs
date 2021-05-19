
using DTO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GSCS_Cameras_Server.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Model>()
                .HasData(new Model
                {
                    Id = 1,
                    Name = "EDUCAM-A",
                    StaticImageUrl = "/cgi-bin/camera",
                    DefaultUsername = "admin",
                    DefaultPassword = "safari",
                    OpenLensUrl = "",
                    CloseLensUrl = ""
                });
            base.OnModelCreating(builder);
        }
    }
}