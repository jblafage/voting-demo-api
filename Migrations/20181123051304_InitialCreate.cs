using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace api_voting_demo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VoteValues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoteResults",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    VoteDate = table.Column<DateTime>(nullable: false),
                    VoteValueId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteResults_VoteValues_VoteValueId",
                        column: x => x.VoteValueId,
                        principalTable: "VoteValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VoteValues",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Cats" });

            migrationBuilder.InsertData(
                table: "VoteValues",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2L, "Dogs" });

            migrationBuilder.CreateIndex(
                name: "IX_VoteResults_VoteValueId",
                table: "VoteResults",
                column: "VoteValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoteResults");

            migrationBuilder.DropTable(
                name: "VoteValues");
        }
    }
}
