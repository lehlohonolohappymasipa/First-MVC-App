using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCLearn.Migrations
{
    /// <inheritdoc />
    public partial class AddedLeaderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "year",
                table: "Students",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "studentNo",
                table: "Students",
                newName: "StudentNo");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "institution",
                table: "Students",
                newName: "Institution");

            migrationBuilder.RenameColumn(
                name: "course",
                table: "Students",
                newName: "Course");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Items",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Items",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Leader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVisionary = table.Column<bool>(type: "bit", nullable: false),
                    HasIntegrity = table.Column<bool>(type: "bit", nullable: false),
                    HasHumility = table.Column<bool>(type: "bit", nullable: false),
                    IsResilient = table.Column<bool>(type: "bit", nullable: false),
                    IsDecisive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leader", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leader");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Students",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "StudentNo",
                table: "Students",
                newName: "studentNo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Institution",
                table: "Students",
                newName: "institution");

            migrationBuilder.RenameColumn(
                name: "Course",
                table: "Students",
                newName: "course");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "id");
        }
    }
}
