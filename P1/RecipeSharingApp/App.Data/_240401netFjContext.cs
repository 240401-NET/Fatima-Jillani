using Microsoft.EntityFrameworkCore;

using App.Models;

namespace App.Data;

public partial class _240401netFjContext : DbContext
{
    public _240401netFjContext()
    {
    }

    public _240401netFjContext(DbContextOptions<_240401netFjContext> options) : base(options){}

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipe__3571ED9BC6610E55");

            entity.ToTable("Recipe");

            entity.Property(e => e.RecipeId).HasColumnName("recipe_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_At");
            entity.Property(e => e.Directions).HasColumnName("directions");
            entity.Property(e => e.Ingredients).HasColumnName("ingredients");
            entity.Property(e => e.PostedBy).HasColumnName("posted_by");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.User).WithMany(p => p.Recipes).IsRequired(false)
                .HasForeignKey(d => d.PostedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Recipe__posted_b__19DFD96B");
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.User_id).HasName("PK__User__B9BE370F908BD0A4");

            entity.ToTable("User");
            

            entity.Property(e => e.User_id).HasColumnName("user_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                // .UseCollation("SQL_Latin1_General_CP1_CI_AS");
                .HasMaxLength(255)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
