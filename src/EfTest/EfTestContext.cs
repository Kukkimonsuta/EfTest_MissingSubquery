using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;

namespace EfTest
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }

    public class Image
    {
        public int Id { get; set; }

        public int Owner_Id { get; set; }
        public virtual User Owner { get; set; }

        public DateTime? Deleted { get; set; }

        public string FileName { get; set; }
    }

    public class Document
    {
        public int Id { get; set; }

        public int Owner_Id { get; set; }
        public virtual User Owner { get; set; }

        public DateTime? Deleted { get; set; }

        public string FileName { get; set; }
    }

    public class EfTestContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Document> Documents { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Images)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.Owner_Id)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Documents)
                .WithOne(e => e.Owner)
                .HasForeignKey(e => e.Owner_Id)
                .IsRequired();
        }
    }
}
