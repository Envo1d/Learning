using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP_HW4.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numeric = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FearLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numeric = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FearLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayersNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyId = table.Column<int>(type: "int", nullable: false),
                    FearLevelId = table.Column<int>(type: "int", nullable: false),
                    PlayersNumberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestRooms_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestRooms_FearLevels_FearLevelId",
                        column: x => x.FearLevelId,
                        principalTable: "FearLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestRooms_PlayersNumbers_PlayersNumberId",
                        column: x => x.PlayersNumberId,
                        principalTable: "PlayersNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Numeric", "Title" },
                values: new object[,]
                {
                    { 4, 4, "Hell" },
                    { 3, 3, "High" },
                    { 2, 2, "Medium" },
                    { 1, 1, "Easy" }
                });

            migrationBuilder.InsertData(
                table: "FearLevels",
                columns: new[] { "Id", "Numeric", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Low" },
                    { 2, 2, "Medium" },
                    { 3, 3, "High" },
                    { 4, 4, "Hell" }
                });

            migrationBuilder.InsertData(
                table: "PlayersNumbers",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 },
                    { 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "QuestRooms",
                columns: new[] { "Id", "Details", "DifficultyId", "FearLevelId", "PlayersNumberId", "Quest", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.", 2, 1, 1, "Lorem Ipsum", "QstRm1" },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.", 1, 3, 1, "Lorem Ipsum", "QstRm4" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.", 4, 3, 3, "Lorem Ipsum", "QstRm2" },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.", 4, 4, 4, "Lorem Ipsum", "QstRm3" },
                    { 5, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam sit amet ullamcorper velit. Cras ullamcorper bibendum urna. Donec ut tellus metus. Sed elementum lorem nibh, id finibus massa tempor vel. In fermentum sem blandit urna gravida, a ultricies elit rutrum. In hac habitasse platea dictumst. Morbi at eleifend quam.", 4, 2, 5, "Lorem Ipsum", "QstRm5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestRooms_DifficultyId",
                table: "QuestRooms",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestRooms_FearLevelId",
                table: "QuestRooms",
                column: "FearLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestRooms_PlayersNumberId",
                table: "QuestRooms",
                column: "PlayersNumberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestRooms");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "FearLevels");

            migrationBuilder.DropTable(
                name: "PlayersNumbers");
        }
    }
}
