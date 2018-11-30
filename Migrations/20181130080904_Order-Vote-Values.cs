using Microsoft.EntityFrameworkCore.Migrations;

namespace api_voting_demo.Migrations
{
    public partial class OrderVoteValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "VoteValues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VoteValues",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Exceeds requirements", 1 }
            );

            migrationBuilder.UpdateData(
                table: "VoteValues",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Order" },
                values: new object[] { "Strong performance", 2 }
            );

            migrationBuilder.InsertData(
                table: "VoteValues",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { 3L, "Interesting", 3 }
            );

            migrationBuilder.InsertData(
                table: "VoteValues",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { 4L, "Needs improvement", 4 }
            );

            migrationBuilder.InsertData(
                table: "VoteValues",
                columns: new[] { "Id", "Name", "Order" },
                values: new object[] { 5L, "Boring", 5 }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "VoteValues");
        }
    }
}
