using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pavel_sorokin_kt_41_21.Database.Helpers;
using pavel_sorokin_kt_41_21.Models;


namespace pavel_sorokin_kt_41_21.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                .HasKey(p => p.DisciplineId)
                .HasName($"pk_{TableName}_discipline_id");

            builder.Property(p => p.DisciplineId)
                    .ValueGeneratedOnAdd();

            builder.Property(p => p.DisciplineId)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор записи дисциплины");

            builder.Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название дисциплины");

            builder.Property(p => p.Direction)
                .IsRequired()
                .HasColumnName("c_direction")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Направление");

            builder.Property(p => p.IsDeleted)
                .IsRequired()
                .HasColumnName("b_deleted")
                .HasColumnType(ColumnType.Bool)
                .HasComment("Статус удаления");


            builder.ToTable(TableName);


        }
    }
}
