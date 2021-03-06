// <auto-generated />
using CourseRegisteration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseRegisteration.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseRegisteration.Models.Courses", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseName = "Java",
                            CourseNumber = 101,
                            Description = "Introduction to JVM and OOPs concept"
                        },
                        new
                        {
                            CourseId = 2,
                            CourseName = "Digital Marketing",
                            CourseNumber = 102,
                            Description = "Learn more about using online marketing to drive traffic."
                        });
                });

            modelBuilder.Entity("CourseRegisteration.Models.Instructors", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            InstructorId = 1,
                            Course = "Java",
                            Email = "Kelsy@yahoo.com",
                            FirstName = "Kelsy",
                            LastName = "Anderson"
                        },
                        new
                        {
                            InstructorId = 2,
                            Course = "Java",
                            Email = "Lucy@yahoo.com",
                            FirstName = "Lucy",
                            LastName = "Smith"
                        });
                });

            modelBuilder.Entity("CourseRegisteration.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegistrationId");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("StudentId");

                    b.ToTable("Registration");

                    b.HasData(
                        new
                        {
                            RegistrationId = 1,
                            CourseId = 2,
                            InstructorId = 2,
                            StudentId = 1,
                            Type = "Fulltime"
                        },
                        new
                        {
                            RegistrationId = 2,
                            CourseId = 2,
                            InstructorId = 2,
                            StudentId = 2,
                            Type = "Parttime"
                        },
                        new
                        {
                            RegistrationId = 3,
                            CourseId = 1,
                            InstructorId = 1,
                            StudentId = 3,
                            Type = "Fulltime"
                        });
                });

            modelBuilder.Entity("CourseRegisteration.Models.Students", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Email = "Peter@Gmail.com",
                            FirstName = "Peter",
                            LastName = "Smith",
                            Phone = "+4339003456"
                        },
                        new
                        {
                            StudentId = 2,
                            Email = "Josh@yahoo.com",
                            FirstName = "Josh",
                            LastName = "Gaby",
                            Phone = "+204567988"
                        },
                        new
                        {
                            StudentId = 3,
                            Email = "Nancy@yahoo.com",
                            FirstName = "Nancy",
                            LastName = "Maria",
                            Phone = "+204987900"
                        });
                });

            modelBuilder.Entity("CourseRegisteration.Models.Registration", b =>
                {
                    b.HasOne("CourseRegisteration.Models.Courses", "course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseRegisteration.Models.Instructors", "instructor")
                        .WithMany()
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseRegisteration.Models.Students", "student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("instructor");

                    b.Navigation("student");
                });
#pragma warning restore 612, 618
        }
    }
}
