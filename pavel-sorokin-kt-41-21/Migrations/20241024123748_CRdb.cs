using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pavel_sorokin_kt_41_21.Migrations
{
    /// <inheritdoc />
    public partial class CRdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_discipline_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    c_direction = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Направление"),
                    b_deleted = table.Column<bool>(type: "bit", nullable: false, comment: "Статус удаления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_group_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Название группы"),
                    DisciplineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.DisciplineId,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_student_firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    c_student_middlename = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    f_group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор группы"),
                    b_deleted = table.Column<bool>(type: "bit", nullable: false, comment: "Статус удаления")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.f_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_group_fk_f_discipline_id",
                table: "cd_group",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "f_group_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");

            migrationBuilder.DropTable(
                name: "cd_discipline");
        }
    }
}
