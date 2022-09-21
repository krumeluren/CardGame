using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardGame.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardHistories_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardHistories_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Number", "Suit" },
                values: new object[,]
                {
                    { 1, "Ace", "Hearts" },
                    { 2, "Two", "Hearts" },
                    { 3, "Three", "Hearts" },
                    { 4, "Four", "Hearts" },
                    { 5, "Five", "Hearts" },
                    { 6, "Six", "Hearts" },
                    { 7, "Seven", "Hearts" },
                    { 8, "Eight", "Hearts" },
                    { 9, "Nine", "Hearts" },
                    { 10, "Ten", "Hearts" },
                    { 11, "Jack", "Hearts" },
                    { 12, "Queen", "Hearts" },
                    { 13, "King", "Hearts" },
                    { 14, "Ace", "Diamonds" },
                    { 15, "Two", "Diamonds" },
                    { 16, "Three", "Diamonds" },
                    { 17, "Four", "Diamonds" },
                    { 18, "Five", "Diamonds" },
                    { 19, "Six", "Diamonds" },
                    { 20, "Seven", "Diamonds" },
                    { 21, "Eight", "Diamonds" },
                    { 22, "Nine", "Diamonds" },
                    { 23, "Ten", "Diamonds" },
                    { 24, "Jack", "Diamonds" },
                    { 25, "Queen", "Diamonds" },
                    { 26, "King", "Diamonds" },
                    { 27, "Ace", "Spades" },
                    { 28, "Two", "Spades" },
                    { 29, "Three", "Spades" },
                    { 30, "Four", "Spades" },
                    { 31, "Five", "Spades" },
                    { 32, "Six", "Spades" },
                    { 33, "Seven", "Spades" },
                    { 34, "Eight", "Spades" },
                    { 35, "Nine", "Spades" },
                    { 36, "Ten", "Spades" },
                    { 37, "Jack", "Spades" },
                    { 38, "Queen", "Spades" },
                    { 39, "King", "Spades" },
                    { 40, "Ace", "Clubs" },
                    { 41, "Two", "Clubs" },
                    { 42, "Three", "Clubs" }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Number", "Suit" },
                values: new object[,]
                {
                    { 43, "Four", "Clubs" },
                    { 44, "Five", "Clubs" },
                    { 45, "Six", "Clubs" },
                    { 46, "Seven", "Clubs" },
                    { 47, "Eight", "Clubs" },
                    { 48, "Nine", "Clubs" },
                    { 49, "Ten", "Clubs" },
                    { 50, "Jack", "Clubs" },
                    { 51, "Queen", "Clubs" },
                    { 52, "King", "Clubs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardHistories_CardId",
                table: "CardHistories",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardHistories_PlayerId",
                table: "CardHistories",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardHistories");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
