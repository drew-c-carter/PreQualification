using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Andrew.Web.PreQualification.Migrations
{
    public partial class Testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ValidationToken",
                table: "CardApplication",
                maxLength: 150,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CardApplicationResult",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accepted = table.Column<bool>(nullable: false),
                    ApplicationID = table.Column<long>(nullable: false),
                    Apr = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
                    CardID = table.Column<long>(nullable: false),
                    CardName = table.Column<string>(maxLength: 150, nullable: true),
                    PromotionalMessage = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardApplicationResult", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CardApplicationResult_CardApplication_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "CardApplication",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardApplicationResult_Card_CardID",
                        column: x => x.CardID,
                        principalTable: "Card",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardApplicationResult_ApplicationID",
                table: "CardApplicationResult",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_CardApplicationResult_CardID",
                table: "CardApplicationResult",
                column: "CardID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardApplicationResult");

            migrationBuilder.DropColumn(
                name: "ValidationToken",
                table: "CardApplication");
        }
    }
}
