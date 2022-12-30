using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AkvelonWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_projects_Projectid",
                table: "tasks");

            migrationBuilder.DropIndex(
                name: "IX_tasks_Projectid",
                table: "tasks");

            migrationBuilder.DropColumn(
                name: "Projectid",
                table: "tasks");

            migrationBuilder.AddColumn<int>(
                name: "project_id",
                table: "tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "project_id",
                table: "tasks");

            migrationBuilder.AddColumn<int>(
                name: "Projectid",
                table: "tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tasks_Projectid",
                table: "tasks",
                column: "Projectid");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_projects_Projectid",
                table: "tasks",
                column: "Projectid",
                principalTable: "projects",
                principalColumn: "id");
        }
    }
}
