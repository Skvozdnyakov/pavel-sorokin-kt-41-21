﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pavel_sorokin_kt_41_21.Database;

#nullable disable

namespace pavel_sorokin_kt_41_21.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20241024123353_UpDiscipine")]
    partial class UpDiscipine
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("pavel_sorokin_kt_41_21.Models.Discipline", b =>
                {
                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("discipline_id")
                        .HasComment("Идентификатор записи дисциплины");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisciplineId"));

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_direction")
                        .HasComment("Направление");

                    b.Property<string>("DisciplineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_discipline_name")
                        .HasComment("Название дисциплины");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("b_deleted")
                        .HasComment("Статус удаления");

                    b.HasKey("DisciplineId")
                        .HasName("pk_cd_discipline_discipline_id");

                    b.ToTable("cd_discipline", (string)null);
                });

            modelBuilder.Entity("pavel_sorokin_kt_41_21.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("group_id")
                        .HasComment("Идентификатор записи группы");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<int>("DisciplineId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_group_name")
                        .HasComment("Название группы");

                    b.HasKey("GroupId")
                        .HasName("pk_cd_group_group_id");

                    b.HasIndex(new[] { "DisciplineId" }, "idx_cd_group_fk_f_discipline_id");

                    b.ToTable("cd_group", (string)null);
                });

            modelBuilder.Entity("pavel_sorokin_kt_41_21.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("student_id")
                        .HasComment("Идентификатор записи студента");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_firstname")
                        .HasComment("Имя студента");

                    b.Property<int>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("f_group_id")
                        .HasComment("Идентификатор группы");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("b_deleted")
                        .HasComment("Статус удаления");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_lastname")
                        .HasComment("Фамилия студента");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_middlename")
                        .HasComment("Отчество студента");

                    b.HasKey("StudentId")
                        .HasName("pk_cd_student_student_id");

                    b.HasIndex(new[] { "GroupId" }, "idx_cd_student_fk_f_group_id");

                    b.ToTable("cd_student", (string)null);
                });

            modelBuilder.Entity("pavel_sorokin_kt_41_21.Models.Group", b =>
                {
                    b.HasOne("pavel_sorokin_kt_41_21.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_discipline_id");

                    b.Navigation("Discipline");
                });

            modelBuilder.Entity("pavel_sorokin_kt_41_21.Models.Student", b =>
                {
                    b.HasOne("pavel_sorokin_kt_41_21.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_f_group_id");

                    b.Navigation("Group");
                });
#pragma warning restore 612, 618
        }
    }
}
