using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pavel_sorokin_kt_41_21.Migrations
{
    /// <inheritdoc />
    public partial class UpDiscipine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines");

            migrationBuilder.RenameTable(
                name: "Disciplines",
                newName: "cd_discipline");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "cd_discipline",
                newName: "b_deleted");

            migrationBuilder.RenameColumn(
                name: "DisciplineName",
                table: "cd_discipline",
                newName: "c_discipline_name");

            migrationBuilder.RenameColumn(
                name: "Direction",
                table: "cd_discipline",
                newName: "c_direction");

            migrationBuilder.RenameColumn(
                name: "DisciplineId",
                table: "cd_discipline",
                newName: "discipline_id");

            migrationBuilder.AlterColumn<bool>(
                name: "b_deleted",
                table: "cd_discipline",
                type: "bit",
                nullable: false,
                comment: "Статус удаления",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "c_discipline_name",
                table: "cd_discipline",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Название дисциплины",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "c_direction",
                table: "cd_discipline",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Направление",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "discipline_id",
                table: "cd_discipline",
                type: "int",
                nullable: false,
                comment: "Идентификатор записи дисциплины",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "pk_cd_discipline_discipline_id",
                table: "cd_discipline",
                column: "discipline_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_cd_discipline_discipline_id",
                table: "cd_discipline");

            migrationBuilder.RenameTable(
                name: "cd_discipline",
                newName: "Disciplines");

            migrationBuilder.RenameColumn(
                name: "c_discipline_name",
                table: "Disciplines",
                newName: "DisciplineName");

            migrationBuilder.RenameColumn(
                name: "c_direction",
                table: "Disciplines",
                newName: "Direction");

            migrationBuilder.RenameColumn(
                name: "b_deleted",
                table: "Disciplines",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "discipline_id",
                table: "Disciplines",
                newName: "DisciplineId");

            migrationBuilder.AlterColumn<string>(
                name: "DisciplineName",
                table: "Disciplines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldComment: "Название дисциплины");

            migrationBuilder.AlterColumn<string>(
                name: "Direction",
                table: "Disciplines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldComment: "Направление");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Disciplines",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Статус удаления");

            migrationBuilder.AlterColumn<int>(
                name: "DisciplineId",
                table: "Disciplines",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Идентификатор записи дисциплины")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines",
                column: "DisciplineId");
        }
    }
}
