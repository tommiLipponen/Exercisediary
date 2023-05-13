using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercisediary.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.CreateTable(
                name: "ExerciseType",
                columns: table => new
                {
                    ExerciseTypeId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Auto generated UUID", collation: "ascii_general_ci"),
                    ExerciseName = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false, collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ExerciseTypeId);
                },
                comment: "Exercise types, like swimming, jogging, etc.")
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    City = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, comment: "Name of the where exercise took place.", collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    Place = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Name of the exercise place, like Central Park, or Heavy Gym.", collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.LocationId);
                },
                comment: "Place where exercise took place like \"New York\" \"Central Park\"")
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Auto generated UUID", collation: "ascii_general_ci"),
                    ExerciseTypeId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "FK from ExerciseType table.", collation: "ascii_general_ci"),
                    LocationId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Place where exercise took place.", collation: "ascii_general_ci"),
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Required, neede for Duration calucation."),
                    EndTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Required, needed for Duration calculation."),
                    Duration = table.Column<int>(type: "int", nullable: true, comment: "Exercise duration in minutes, data base calculates."),
                    BmpCount = table.Column<int>(type: "int", nullable: true, comment: "Average heart beat rate."),
                    CaloriesBurned = table.Column<int>(type: "int", nullable: true, comment: "Calories burned during this exercise."),
                    Notes = table.Column<string>(type: "longtext", nullable: true, comment: "Exercise notes.", collation: "utf8mb3_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    StartpointLat = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true, comment: "X and Y coordinates of Startpoint."),
                    StartpointLong = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    EndpointLat = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true),
                    EndpointLong = table.Column<decimal>(type: "decimal(9,6)", precision: 9, scale: 6, nullable: true, comment: "X and Y coordinates of Endpoint."),
                    MetersTraveled = table.Column<int>(type: "int", nullable: true, comment: "Distance travelled.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ExerciseId);
                    table.ForeignKey(
                        name: "FK_ExerciseTypeId_Exercises",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseType",
                        principalColumn: "ExerciseTypeId");
                    table.ForeignKey(
                        name: "FK_LocationId_Exercise",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId");
                },
                comment: "Exercise instances and their details.")
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "FK_ExerciseTypeId_Exercises_idx",
                table: "Exercise",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "FK_LocationId_Exercise_idx",
                table: "Exercise",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "idx_ExerciseTypes_ExerciseType",
                table: "ExerciseType",
                column: "ExerciseName");

            migrationBuilder.CreateIndex(
                name: "idx_Location_City",
                table: "Location",
                column: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "ExerciseType");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
