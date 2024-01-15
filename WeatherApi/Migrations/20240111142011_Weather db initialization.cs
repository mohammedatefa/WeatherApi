using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApi.Migrations
{
    /// <inheritdoc />
    public partial class Weatherdbinitialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lat = table.Column<double>(type: "float", nullable: false),
                    lon = table.Column<double>(type: "float", nullable: false),
                    localtime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Current",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    temp_c = table.Column<double>(type: "float", nullable: false),
                    temp_f = table.Column<double>(type: "float", nullable: false),
                    is_day = table.Column<int>(type: "int", nullable: false),
                    conditionId = table.Column<int>(type: "int", nullable: false),
                    wind_mph = table.Column<double>(type: "float", nullable: false),
                    wind_kph = table.Column<double>(type: "float", nullable: false),
                    wind_degree = table.Column<int>(type: "int", nullable: false),
                    wind_dir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cloud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Current", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Current_Condition_conditionId",
                        column: x => x.conditionId,
                        principalTable: "Condition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuontryWeather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationID = table.Column<int>(type: "int", nullable: false),
                    currentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuontryWeather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuontryWeather_Current_currentId",
                        column: x => x.currentId,
                        principalTable: "Current",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuontryWeather_Location_locationID",
                        column: x => x.locationID,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuontryWeather_currentId",
                table: "CuontryWeather",
                column: "currentId");

            migrationBuilder.CreateIndex(
                name: "IX_CuontryWeather_locationID",
                table: "CuontryWeather",
                column: "locationID");

            migrationBuilder.CreateIndex(
                name: "IX_Current_conditionId",
                table: "Current",
                column: "conditionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuontryWeather");

            migrationBuilder.DropTable(
                name: "Current");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Condition");
        }
    }
}
