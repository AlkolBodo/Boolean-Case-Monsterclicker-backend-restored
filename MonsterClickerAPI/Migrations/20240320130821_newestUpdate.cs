using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterClickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class newestUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_player_inventory_user_player_id",
                table: "player_inventory");

            migrationBuilder.RenameColumn(
                name: "player_id",
                table: "player_inventory",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_player_inventory_player_id",
                table: "player_inventory",
                newName: "IX_player_inventory_user_id");

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "drop_rate", "item_id", "min_drop" },
                values: new object[] { 61f, 1, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "drop_rate", "max_drop", "min_drop" },
                values: new object[] { 58f, 5, 1 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 72f, 3, 4, 3, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 36f, 2, 3, 1, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "drop_rate", "item_id", "min_drop", "monster_id" },
                values: new object[] { 78f, 4, 1, 5 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 6,
                column: "max_drop",
                value: 7);

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 66f, 4, 5, 3, 6 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "drop_rate", "item_id", "min_drop" },
                values: new object[] { 71f, 3, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 30f, 2, 4, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 78f, 4, 6, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 57f, 3, 6, 8 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 33f, 4, 2, 1, 9 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "drop_rate", "item_id", "min_drop", "monster_id" },
                values: new object[] { 28f, 3, 2, 9 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 29f, 2, 6, 10 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 41f, 1, 4, 11 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "drop_rate", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 32f, 4, 1, 12 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 28f, 2, 7, 3, 13 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 76f, 2, 7, 14 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "drop_rate", "item_id" },
                values: new object[] { 20f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 59f, 4, 6, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 33f, 1, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 37f, 2, 5, 17 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 77f, 4, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "drop_rate", "max_drop", "min_drop" },
                values: new object[] { 51f, 6, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 49f, 1, 8 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "drop_rate", "max_drop", "min_drop" },
                values: new object[] { 24f, 4, 1 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "drop_rate", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 35f, 3, 1, 20 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 76f, 3, 7, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 48f, 2, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 72f, 3, 6, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 74f, 2, 6, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 70f, 1, 4, 3, 24 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 60f, 4, 4, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 20f, 1, 3, 25 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 77f, 1, 3, 1 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 63f, 3, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 74f, 2, 7, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "drop_rate", "max_drop", "min_drop" },
                values: new object[] { 56f, 4, 1 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "drop_rate", "item_id", "min_drop" },
                values: new object[] { 49f, 3, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 50f, 3, 7, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 41,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 21f, 1, 4, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 5f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 3,
                column: "gold_drop",
                value: 3);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 9f, 4 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 5,
                column: "extra_health",
                value: 7f);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 8f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 6f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 5f, 4 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 9f, 1 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 4 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 5f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 8f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 8f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 8f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 16,
                column: "gold_drop",
                value: 1);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 9f, 1 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 18,
                column: "gold_drop",
                value: 3);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 5f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 6f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 9f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 22,
                column: "gold_drop",
                value: 3);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 23,
                column: "gold_drop",
                value: 3);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 24,
                column: "gold_drop",
                value: 2);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 25,
                column: "extra_health",
                value: 7f);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 26,
                column: "extra_health",
                value: 9f);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 9f, 4 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 5f, 4 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 5f, 1 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 30,
                column: "extra_health",
                value: 8f);

            migrationBuilder.AddForeignKey(
                name: "FK_player_inventory_user_user_id",
                table: "player_inventory",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_player_inventory_user_user_id",
                table: "player_inventory");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "player_inventory",
                newName: "player_id");

            migrationBuilder.RenameIndex(
                name: "IX_player_inventory_user_id",
                table: "player_inventory",
                newName: "IX_player_inventory_player_id");

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "drop_rate", "item_id", "min_drop" },
                values: new object[] { 42f, 4, 1 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "drop_rate", "max_drop", "min_drop" },
                values: new object[] { 38f, 3, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 63f, 4, 5, 2, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 77f, 3, 4, 2, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "drop_rate", "item_id", "min_drop", "monster_id" },
                values: new object[] { 40f, 2, 2, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 6,
                column: "max_drop",
                value: 8);

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 71f, 3, 4, 1, 5 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "drop_rate", "item_id", "min_drop" },
                values: new object[] { 57f, 4, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 69f, 4, 3, 1 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 21f, 3, 5, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 35f, 4, 3, 9 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 40f, 3, 5, 4, 10 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "drop_rate", "item_id", "min_drop", "monster_id" },
                values: new object[] { 65f, 4, 3, 10 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 42f, 3, 3, 11 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 46f, 4, 2, 12 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "drop_rate", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 64f, 5, 4, 13 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 74f, 3, 6, 2, 14 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 74f, 4, 4, 15 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "drop_rate", "item_id" },
                values: new object[] { 55f, 1 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 77f, 1, 5, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 35f, 2, 6 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 64f, 3, 7, 18 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 56f, 1, 6 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "drop_rate", "max_drop", "min_drop" },
                values: new object[] { 25f, 5, 1 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 67f, 2, 6 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "drop_rate", "max_drop", "min_drop" },
                values: new object[] { 37f, 3, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "drop_rate", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 37f, 6, 4, 21 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 35f, 1, 5, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 79f, 4, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 46f, 1, 7, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 51f, 3, 4, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[] { 69f, 2, 8, 4, 25 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 21f, 3, 7, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "drop_rate", "item_id", "max_drop", "monster_id" },
                values: new object[] { 56f, 2, 6, 26 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 22f, 3, 5, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "drop_rate", "item_id", "max_drop" },
                values: new object[] { 61f, 4, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 23f, 1, 5, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "drop_rate", "max_drop", "min_drop" },
                values: new object[] { 28f, 7, 4 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "drop_rate", "item_id", "min_drop" },
                values: new object[] { 37f, 2, 3 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 33f, 1, 5, 2 });

            migrationBuilder.UpdateData(
                table: "monster_item_table",
                keyColumn: "id",
                keyValue: 41,
                columns: new[] { "drop_rate", "item_id", "max_drop", "min_drop" },
                values: new object[] { 53f, 3, 5, 1 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 8f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 8f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 3,
                column: "gold_drop",
                value: 4);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 5,
                column: "extra_health",
                value: 6f);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 1 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 9f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 6f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 6f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 8f, 4 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 5f, 1 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 1 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 9f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 16,
                column: "gold_drop",
                value: 2);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 8f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 18,
                column: "gold_drop",
                value: 2);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 9f, 1 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 4 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 6f, 1 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 22,
                column: "gold_drop",
                value: 4);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 23,
                column: "gold_drop",
                value: 1);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 24,
                column: "gold_drop",
                value: 1);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 25,
                column: "extra_health",
                value: 8f);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 26,
                column: "extra_health",
                value: 7f);

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 6f, 3 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "extra_health", "gold_drop" },
                values: new object[] { 7f, 2 });

            migrationBuilder.UpdateData(
                table: "monster_stats",
                keyColumn: "id",
                keyValue: 30,
                column: "extra_health",
                value: 5f);

            migrationBuilder.AddForeignKey(
                name: "FK_player_inventory_user_player_id",
                table: "player_inventory",
                column: "player_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
