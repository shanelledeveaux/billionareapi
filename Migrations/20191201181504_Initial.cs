using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace billionareapi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CountryFullName = table.Column<string>(nullable: true),
                    CountryCommonName = table.Column<string>(nullable: true),
                    CountryAbbreviation = table.Column<string>(nullable: true),
                    RegionDescription = table.Column<string>(nullable: true),
                    RegionAbbreviation = table.Column<string>(nullable: true),
                    MetroArea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Pronoun",
                columns: table => new
                {
                    PronounId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Subject = table.Column<string>(nullable: true),
                    Object = table.Column<string>(nullable: true),
                    Posessive = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pronoun", x => x.PronounId);
                });

            migrationBuilder.CreateTable(
                name: "Billionare",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    NetWorth = table.Column<int>(nullable: false),
                    PronounId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billionare", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Billionare_Pronoun_PronounId",
                        column: x => x.PronounId,
                        principalTable: "Pronoun",
                        principalColumn: "PronounId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillionareAccomplishment",
                columns: table => new
                {
                    AccomplishmentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    BillionarePersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillionareAccomplishment", x => x.AccomplishmentId);
                    table.ForeignKey(
                        name: "FK_BillionareAccomplishment_Billionare_BillionarePersonId",
                        column: x => x.BillionarePersonId,
                        principalTable: "Billionare",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillionareIncomeSource",
                columns: table => new
                {
                    EmploymentId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Company = table.Column<string>(nullable: true),
                    Job = table.Column<string>(nullable: true),
                    StartYear = table.Column<int>(nullable: true),
                    EndYear = table.Column<int>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    BillionarePersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillionareIncomeSource", x => x.EmploymentId);
                    table.ForeignKey(
                        name: "FK_BillionareIncomeSource_Billionare_BillionarePersonId",
                        column: x => x.BillionarePersonId,
                        principalTable: "Billionare",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Institution = table.Column<string>(nullable: true),
                    FieldOfStudy = table.Column<string>(nullable: true),
                    StartYear = table.Column<int>(nullable: true),
                    EndYear = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Education_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Education_Billionare_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Billionare",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Billionare_PronounId",
                table: "Billionare",
                column: "PronounId");

            migrationBuilder.CreateIndex(
                name: "IX_BillionareAccomplishment_BillionarePersonId",
                table: "BillionareAccomplishment",
                column: "BillionarePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BillionareIncomeSource_BillionarePersonId",
                table: "BillionareIncomeSource",
                column: "BillionarePersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_LocationId",
                table: "Education",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_PersonId",
                table: "Education",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillionareAccomplishment");

            migrationBuilder.DropTable(
                name: "BillionareIncomeSource");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Billionare");

            migrationBuilder.DropTable(
                name: "Pronoun");
        }
    }
}
