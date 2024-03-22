using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MonsterClickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class FinalFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    item_name = table.Column<string>(type: "text", nullable: false),
                    item_sprite_url = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "monster",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    monster_name = table.Column<string>(type: "text", nullable: false),
                    monster_sprite_ulr = table.Column<string>(type: "text", nullable: false),
                    world_location = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monster", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_stats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    click_damage = table.Column<float>(type: "real", nullable: false),
                    crit_chance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_stats", x => x.id);
                    table.ForeignKey(
                        name: "FK_player_stats_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_statistic",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    clicks = table.Column<int>(type: "integer", nullable: false),
                    monsters_killed = table.Column<int>(type: "integer", nullable: false),
                    gold = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_statistic", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_statistic_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_player_inventory_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_player_inventory_item_item_id",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "monster_item_table",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    monster_id = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    drop_rate = table.Column<float>(type: "real", nullable: false),
                    min_drop = table.Column<int>(type: "integer", nullable: false),
                    max_drop = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monster_item_table", x => x.id);
                    table.ForeignKey(
                        name: "FK_monster_item_table_item_item_id",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_monster_item_table_monster_monster_id",
                        column: x => x.monster_id,
                        principalTable: "monster",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "monster_stats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    monster_id = table.Column<int>(type: "integer", nullable: false),
                    basehealth = table.Column<float>(type: "real", nullable: false),
                    extra_health = table.Column<float>(type: "real", nullable: false),
                    gold_drop = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monster_stats", x => x.id);
                    table.ForeignKey(
                        name: "FK_monster_stats_monster_monster_id",
                        column: x => x.monster_id,
                        principalTable: "monster",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "item",
                columns: new[] { "id", "item_name", "item_sprite_url", "value" },
                values: new object[,]
                {
                    { 1, "Bone", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Broken%20Disgusting%20Fork", 11f },
                    { 2, "Blob", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Ancient%20Sweet%20Bag", 16f },
                    { 3, "Spirit energy", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Fossilized%20Banana", 13f },
                    { 4, "Scrap", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Grand%20Old%20Bag", 3f }
                });

            migrationBuilder.InsertData(
                table: "monster",
                columns: new[] { "id", "world_location", "monster_name", "monster_sprite_ulr" },
                values: new object[,]
                {
                    { 1, 0, "Mass of Bones", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Broken%20Amulet.png" },
                    { 2, 0, "Fallen Angel", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Broken%20Disgusting%20Fork.png" },
                    { 3, 0, "Crypt Bat", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Ancient%20Sweet%20Bag.png" },
                    { 4, 0, "Purple Demon", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Fossilized%20Banana.png" },
                    { 5, 0, "Starfish Lich", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Grand%20Old%20Bag.png" },
                    { 6, 0, "Wraith", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Huge%20Book.png" },
                    { 7, 0, "Valkyrie", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Overlord%20(1).png" },
                    { 8, 0, "Vengeful chimera", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Salty%20Beet.png" },
                    { 9, 0, "Arms", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Sweet%20Sunflower.png" },
                    { 10, 0, "Broken warrior", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Terrible%20Artichoke.png" },
                    { 11, 1, "Possessed Corn", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Big%20Corn.png" },
                    { 12, 1, "Haunted Beetle", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Dark%20Amulet.png" },
                    { 13, 1, "Corrupted Mantis", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Ancient%20Shallot.png" },
                    { 14, 1, "Toxic Presence", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Huge%20Fork.png" },
                    { 15, 1, "Corrupted spider", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Massive%20Pencil.png" },
                    { 16, 1, "Corrupting fungus", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Quartz%20Cloud.png" },
                    { 17, 1, "Mysterious Bread", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Mysterious%20Bread.png" },
                    { 18, 1, "Corrupted lizard", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Small%20Sandals.png" },
                    { 19, 1, "Farm golem", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Stone%20Carrot.png" },
                    { 20, 1, "Forgotten farmer", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Spicy%20Sandals%20of%20Purifying.png" },
                    { 21, 2, "Ancient golem", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Cheesy%20Broccoli.png" },
                    { 22, 2, "Azure Ghoul", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Crusty%20Beautiful%20Vitamins.png" },
                    { 23, 2, "Cannonhead", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Dark%20Metal%20Alien.png" },
                    { 24, 2, "Futuristic frog", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Floating%20Banana.png" },
                    { 25, 2, "Surveilance Drone", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Fresh%20Cheesy%20Pepper.png" },
                    { 26, 2, "PK-3000", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Light%20Gem.png" },
                    { 27, 2, "Atlantian spirit", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Salty%20Banana.png" },
                    { 28, 2, "Emerald squid", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Spicy%20Quartz%20Sunflower.png" },
                    { 29, 2, "Sentient shrine", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Toxic%20Wooden%20Finger.png" },
                    { 30, 2, "Watcher", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Unique%20Squash.png" }
                });

            migrationBuilder.InsertData(
                table: "monster_item_table",
                columns: new[] { "id", "drop_rate", "item_id", "max_drop", "min_drop", "monster_id" },
                values: new object[,]
                {
                    { 1, 77f, 3, 3, 1, 1 },
                    { 2, 46f, 4, 5, 4, 2 },
                    { 3, 27f, 2, 5, 1, 3 },
                    { 4, 47f, 1, 5, 4, 3 },
                    { 5, 52f, 2, 2, 1, 4 },
                    { 6, 36f, 1, 4, 3, 4 },
                    { 7, 58f, 3, 6, 4, 5 },
                    { 8, 29f, 4, 3, 1, 6 },
                    { 9, 76f, 1, 2, 1, 6 },
                    { 10, 70f, 1, 3, 1, 7 },
                    { 11, 57f, 4, 5, 4, 7 },
                    { 12, 28f, 4, 7, 3, 8 },
                    { 13, 58f, 3, 6, 4, 9 },
                    { 14, 60f, 3, 7, 4, 10 },
                    { 15, 55f, 2, 5, 3, 10 },
                    { 16, 28f, 4, 4, 1, 11 },
                    { 17, 50f, 1, 4, 3, 11 },
                    { 18, 64f, 1, 7, 3, 12 },
                    { 19, 35f, 1, 6, 3, 13 },
                    { 20, 58f, 1, 6, 3, 14 },
                    { 21, 29f, 4, 7, 4, 14 },
                    { 22, 41f, 4, 2, 1, 15 },
                    { 23, 25f, 3, 7, 4, 16 },
                    { 24, 79f, 1, 5, 4, 17 },
                    { 25, 70f, 3, 3, 1, 17 },
                    { 26, 52f, 2, 5, 2, 18 },
                    { 27, 24f, 3, 4, 3, 19 },
                    { 28, 32f, 2, 5, 2, 20 },
                    { 29, 58f, 1, 2, 1, 20 },
                    { 30, 53f, 1, 6, 3, 21 },
                    { 31, 39f, 4, 7, 4, 22 },
                    { 32, 70f, 1, 3, 2, 23 },
                    { 33, 30f, 1, 8, 4, 24 },
                    { 34, 74f, 3, 7, 4, 24 },
                    { 35, 39f, 3, 4, 1, 25 },
                    { 36, 74f, 1, 3, 2, 25 },
                    { 37, 63f, 3, 2, 1, 26 },
                    { 38, 53f, 1, 3, 2, 27 },
                    { 39, 27f, 4, 3, 2, 27 },
                    { 40, 74f, 4, 6, 4, 28 },
                    { 41, 68f, 1, 7, 3, 29 },
                    { 42, 76f, 4, 2, 1, 30 },
                    { 43, 47f, 2, 6, 4, 30 }
                });

            migrationBuilder.InsertData(
                table: "monster_stats",
                columns: new[] { "id", "basehealth", "extra_health", "gold_drop", "monster_id" },
                values: new object[,]
                {
                    { 1, 9f, 9f, 2, 1 },
                    { 2, 9f, 7f, 1, 2 },
                    { 3, 6f, 8f, 1, 3 },
                    { 4, 8f, 6f, 1, 4 },
                    { 5, 5f, 5f, 1, 5 },
                    { 6, 9f, 8f, 4, 6 },
                    { 7, 8f, 7f, 3, 7 },
                    { 8, 7f, 6f, 4, 8 },
                    { 9, 6f, 8f, 1, 9 },
                    { 10, 6f, 7f, 4, 10 },
                    { 11, 5f, 8f, 1, 11 },
                    { 12, 6f, 5f, 1, 12 },
                    { 13, 5f, 9f, 2, 13 },
                    { 14, 7f, 5f, 3, 14 },
                    { 15, 8f, 5f, 2, 15 },
                    { 16, 5f, 6f, 2, 16 },
                    { 17, 6f, 9f, 1, 17 },
                    { 18, 8f, 8f, 2, 18 },
                    { 19, 8f, 6f, 2, 19 },
                    { 20, 5f, 8f, 3, 20 },
                    { 21, 7f, 5f, 2, 21 },
                    { 22, 8f, 9f, 1, 22 },
                    { 23, 5f, 8f, 3, 23 },
                    { 24, 6f, 5f, 1, 24 },
                    { 25, 9f, 6f, 4, 25 },
                    { 26, 5f, 7f, 4, 26 },
                    { 27, 9f, 8f, 1, 27 },
                    { 28, 5f, 7f, 4, 28 },
                    { 29, 6f, 5f, 1, 29 },
                    { 30, 5f, 6f, 2, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_monster_item_table_item_id",
                table: "monster_item_table",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_monster_item_table_monster_id",
                table: "monster_item_table",
                column: "monster_id");

            migrationBuilder.CreateIndex(
                name: "IX_monster_stats_monster_id",
                table: "monster_stats",
                column: "monster_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_inventory_item_id",
                table: "player_inventory",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_inventory_user_id",
                table: "player_inventory",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_stats_user_id",
                table: "player_stats",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_statistic_user_id",
                table: "user_statistic",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "monster_item_table");

            migrationBuilder.DropTable(
                name: "monster_stats");

            migrationBuilder.DropTable(
                name: "player_inventory");

            migrationBuilder.DropTable(
                name: "player_stats");

            migrationBuilder.DropTable(
                name: "user_statistic");

            migrationBuilder.DropTable(
                name: "monster");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
