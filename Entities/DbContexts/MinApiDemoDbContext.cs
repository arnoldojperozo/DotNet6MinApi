using Microsoft.EntityFrameworkCore;

namespace DotNet6MinApi.Entities.DbContexts
{
    public partial class MinApiDemoDbContext : DbContext
    {
        public MinApiDemoDbContext()
        {
        }

        public MinApiDemoDbContext(DbContextOptions<MinApiDemoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DbSecurityRole> DbSecurityRole { get; set; } = null!;
        public virtual DbSet<DbSecurityUserAction> DbSecurityUserAction { get; set; } = null!;
        public virtual DbSet<DbUser> DbUser { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=MinApiDemo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbSecurityRole>(entity =>
            {
                entity.HasKey(e => e.IdSecurityRole);

                entity.ToTable("DB_SECURITY_ROLE");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.SecurityRoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<DbSecurityUserAction>(entity =>
            {
                entity.HasKey(e => e.IdSecurityUserAction);

                entity.ToTable("DB_SECURITY_USER_ACTION");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.DbSecurityUserAction)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_DB_SECURITY_USER_ACTION_DB_USER");
            });

            modelBuilder.Entity<DbUser>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("DB_USER");

                entity.Property(e => e.Client).HasMaxLength(50);

                entity.Property(e => e.ClientIp).HasMaxLength(50);

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gsm)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsRoleLock).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSecurityRoleNavigation)
                    .WithMany(p => p.DbUser)
                    .HasForeignKey(d => d.IdSecurityRole)
                    .HasConstraintName("FK_DB_USER_DB_SECURITY_ROLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
