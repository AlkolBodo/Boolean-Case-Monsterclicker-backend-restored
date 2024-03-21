using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MonsterClickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
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
                    monsters_killed = table.Column<int>(type: "integer", nullable: false)
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
                    { 1, "Bone", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Broken%20Disgusting%20Fork", 16f },
                    { 2, "Blob", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Ancient%20Sweet%20Bag", 16f },
                    { 3, "Spirit energy", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Fossilized%20Banana", 10f },
                    { 4, "Scrap", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Grand%20Old%20Bag", 1f }
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
                    { 1, 22f, 1, 7, 3, 1 },
                    { 2, 60f, 2, 6, 3, 2 },
                    { 3, 39f, 1, 6, 4, 2 },
                    { 4, 30f, 4, 6, 2, 3 },
                    { 5, 55f, 2, 5, 4, 4 },
                    { 6, 40f, 3, 7, 4, 5 },
                    { 7, 78f, 2, 2, 1, 6 },
                    { 8, 43f, 4, 3, 1, 7 },
                    { 9, 72f, 3, 5, 2, 7 },
                    { 10, 34f, 1, 2, 1, 8 },
                    { 11, 38f, 1, 3, 2, 9 },
                    { 12, 55f, 4, 6, 3, 9 },
                    { 13, 29f, 3, 5, 2, 10 },
                    { 14, 75f, 4, 4, 3, 11 },
                    { 15, 47f, 3, 6, 2, 12 },
                    { 16, 74f, 4, 3, 1, 13 },
                    { 17, 76f, 1, 8, 4, 14 },
                    { 18, 23f, 1, 5, 2, 15 },
                    { 19, 44f, 4, 5, 4, 15 },
                    { 20, 55f, 2, 4, 1, 16 },
                    { 21, 33f, 3, 6, 4, 16 },
                    { 22, 39f, 4, 7, 3, 17 },
                    { 23, 36f, 2, 6, 2, 17 },
                    { 24, 67f, 4, 4, 2, 18 },
                    { 25, 33f, 4, 7, 3, 19 },
                    { 26, 49f, 3, 3, 2, 20 },
                    { 27, 43f, 4, 6, 3, 20 },
                    { 28, 79f, 4, 7, 3, 21 },
                    { 29, 39f, 3, 4, 3, 22 },
                    { 30, 28f, 3, 3, 2, 23 },
                    { 31, 21f, 2, 4, 3, 23 },
                    { 32, 20f, 2, 6, 2, 24 },
                    { 33, 20f, 4, 6, 2, 24 },
                    { 34, 30f, 2, 7, 3, 25 },
                    { 35, 33f, 3, 5, 3, 26 },
                    { 36, 56f, 1, 5, 1, 27 },
                    { 37, 53f, 3, 5, 3, 28 },
                    { 38, 23f, 4, 5, 4, 28 },
                    { 39, 60f, 4, 4, 1, 29 },
                    { 40, 28f, 3, 8, 4, 29 },
                    { 41, 45f, 4, 3, 1, 30 },
                    { 42, 75f, 2, 4, 3, 30 }
                });

            migrationBuilder.InsertData(
                table: "monster_stats",
                columns: new[] { "id", "basehealth", "extra_health", "gold_drop", "monster_id" },
                values: new object[,]
                {
                    { 1, 8f, 5f, 1, 1 },
                    { 2, 9f, 5f, 2, 2 },
                    { 3, 5f, 8f, 3, 3 },
                    { 4, 9f, 6f, 1, 4 },
                    { 5, 6f, 9f, 2, 5 },
                    { 6, 7f, 9f, 3, 6 },
                    { 7, 8f, 9f, 2, 7 },
                    { 8, 6f, 9f, 2, 8 },
                    { 9, 7f, 7f, 3, 9 },
                    { 10, 7f, 5f, 2, 10 },
                    { 11, 5f, 8f, 3, 11 },
                    { 12, 8f, 7f, 2, 12 },
                    { 13, 5f, 7f, 2, 13 },
                    { 14, 9f, 6f, 1, 14 },
                    { 15, 5f, 6f, 2, 15 },
                    { 16, 7f, 5f, 1, 16 },
                    { 17, 7f, 8f, 4, 17 },
                    { 18, 9f, 6f, 2, 18 },
                    { 19, 9f, 5f, 1, 19 },
                    { 20, 5f, 5f, 1, 20 },
                    { 21, 8f, 8f, 4, 21 },
                    { 22, 5f, 9f, 3, 22 },
                    { 23, 6f, 5f, 4, 23 },
                    { 24, 5f, 6f, 2, 24 },
                    { 25, 9f, 6f, 3, 25 },
                    { 26, 7f, 8f, 4, 26 },
                    { 27, 6f, 9f, 1, 27 },
                    { 28, 8f, 6f, 1, 28 },
                    { 29, 5f, 5f, 2, 29 },
                    { 30, 8f, 5f, 2, 30 }
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
