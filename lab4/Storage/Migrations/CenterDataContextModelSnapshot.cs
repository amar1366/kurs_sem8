// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab4.Storage.Migrations;

namespace lab4.Storage.Migrations
{
    [DbContext(typeof(CenterDataContext))]
    partial class CenterDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab4.Storage.Entity.Department", b =>
                {
                    b.Property<Guid>("dNomber")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DepNomber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("dName")
                        .IsRequired()
                        .HasColumnName("DepName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("dNomber");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("lab4.Storage.Entity.Professor", b =>
                {
                    b.Property<Guid>("pNomber")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProfNomber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UniversityId")
                        .HasColumnName("UniversityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("birthday")
                        .HasColumnName("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("middlename")
                        .IsRequired()
                        .HasColumnName("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnName("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pNomber");

                    b.HasIndex("UniversityId");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("lab4.Storage.Entity.University", b =>
                {
                    b.Property<Guid>("uNomber")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UniNomber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartamentId")
                        .HasColumnName("DepartamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DepartmentdNomber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("uName")
                        .IsRequired()
                        .HasColumnName("UniName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("uNomber");

                    b.HasIndex("DepartmentdNomber");

                    b.ToTable("University");
                });

            modelBuilder.Entity("lab4.Storage.Entity.Professor", b =>
                {
                    b.HasOne("lab4.Storage.Entity.University", null)
                        .WithMany("Professors")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lab4.Storage.Entity.University", b =>
                {
                    b.HasOne("lab4.Storage.Entity.Department", null)
                        .WithMany("Universitys")
                        .HasForeignKey("DepartmentdNomber");
                });
#pragma warning restore 612, 618
        }
    }
}
