using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EfTest;

namespace EfTest.Migrations
{
    [DbContext(typeof(EfTestContext))]
    [Migration("20160228165829_InitialStructure")]
    partial class InitialStructure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfTest.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("FileName");

                    b.Property<int>("Owner_Id");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EfTest.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("FileName");

                    b.Property<int>("Owner_Id");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EfTest.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EfTest.Document", b =>
                {
                    b.HasOne("EfTest.User")
                        .WithMany()
                        .HasForeignKey("Owner_Id");
                });

            modelBuilder.Entity("EfTest.Image", b =>
                {
                    b.HasOne("EfTest.User")
                        .WithMany()
                        .HasForeignKey("Owner_Id");
                });
        }
    }
}
