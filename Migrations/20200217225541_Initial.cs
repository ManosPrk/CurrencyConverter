using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyConverter.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    CurrencyId = table.Column<Guid>(nullable: false),
                    IsoCode = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    ExchangeRateId = table.Column<Guid>(nullable: false),
                    FromCurrencyId = table.Column<Guid>(nullable: true),
                    ToCurrencyId = table.Column<Guid>(nullable: true),
                    Ratio = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.ExchangeRateId);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_FromCurrencyId",
                        column: x => x.FromCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_ToCurrencyId",
                        column: x => x.ToCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FromRelations",
                columns: table => new
                {
                    CurrencyRelationId = table.Column<Guid>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FromRelations", x => x.CurrencyRelationId);
                    table.ForeignKey(
                        name: "FK_FromRelations_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToRelations",
                columns: table => new
                {
                    CurrencyRelationId = table.Column<Guid>(nullable: false),
                    CurrencyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToRelations", x => x.CurrencyRelationId);
                    table.ForeignKey(
                        name: "FK_ToRelations_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FromCurrencies",
                columns: table => new
                {
                    FromCurrencyId = table.Column<Guid>(nullable: false),
                    FromRelationId = table.Column<Guid>(nullable: false),
                    IsoCode = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FromCurrencies", x => x.FromCurrencyId);
                    table.ForeignKey(
                        name: "FK_FromCurrencies_FromRelations_FromRelationId",
                        column: x => x.FromRelationId,
                        principalTable: "FromRelations",
                        principalColumn: "CurrencyRelationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToCurrencies",
                columns: table => new
                {
                    ToCurrencyId = table.Column<Guid>(nullable: false),
                    ToRelationId = table.Column<Guid>(nullable: false),
                    IsoCode = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToCurrencies", x => x.ToCurrencyId);
                    table.ForeignKey(
                        name: "FK_ToCurrencies_ToRelations_ToRelationId",
                        column: x => x.ToRelationId,
                        principalTable: "ToRelations",
                        principalColumn: "CurrencyRelationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_FromCurrencyId",
                table: "ExchangeRates",
                column: "FromCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_ToCurrencyId",
                table: "ExchangeRates",
                column: "ToCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_FromCurrencies_FromRelationId",
                table: "FromCurrencies",
                column: "FromRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_FromRelations_CurrencyId",
                table: "FromRelations",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ToCurrencies_ToRelationId",
                table: "ToCurrencies",
                column: "ToRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_ToRelations_CurrencyId",
                table: "ToRelations",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "FromCurrencies");

            migrationBuilder.DropTable(
                name: "ToCurrencies");

            migrationBuilder.DropTable(
                name: "FromRelations");

            migrationBuilder.DropTable(
                name: "ToRelations");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
