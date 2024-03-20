using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MonsterClickerAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeederData : Migration
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
                    item_sprite_url = table.Column<string>(type: "text", nullable: false)
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
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "player_stats",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    click_damage = table.Column<float>(type: "real", nullable: false),
                    crit_chance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_stats", x => x.id);
                    table.ForeignKey(
                        name: "FK_player_stats_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_statistic",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User = table.Column<int>(type: "integer", nullable: false),
                    clicks = table.Column<int>(type: "integer", nullable: false),
                    monsters_killed = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_statistic", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_statistic_user_User",
                        column: x => x.User,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "player_inventory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    player_id = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_inventory", x => x.id);
                    table.ForeignKey(
                        name: "FK_player_inventory_item_item_id",
                        column: x => x.item_id,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_player_inventory_player_stats_player_id",
                        column: x => x.player_id,
                        principalTable: "player_stats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "item",
                columns: new[] { "id", "item_name", "item_sprite_url" },
                values: new object[,]
                {
                    { 1, "Bone", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Broken%20Discusting%20Fork" },
                    { 2, "Blob", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Ancient%20Sweet%20Bag" },
                    { 3, "Spirit energy", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Fossilized%20Banana" },
                    { 4, "Scrap", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Grand%20Old%20Bag" }
                });

            migrationBuilder.InsertData(
                table: "monster",
                columns: new[] { "id", "world_location", "monster_name", "monster_sprite_ulr" },
                values: new object[,]
                {
                    { 1, 0, "Mass of Bones", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Broken%20Amulet.png" },
                    { 2, 0, "Fallen Angel", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Broken%20Discusting%20Fork.png" },
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
                    { 20, 1, "Forgotten farmer", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Spicy%20Sandals%20Of%20Purifying.png" },
                    { 21, 2, "Ancient golem", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Cheesy%20Broccoli.png" },
                    { 22, 2, "Azure Ghoul", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Crusty%20Beautiful%20Vitamins.png" },
                    { 23, 2, "Cannonhead", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Dark%20Metal%20Alien.png" },
                    { 24, 2, "Futuristic frog", "https://raw.githubusercontent.com/AlkolBodo/Boolean-Case-Monsterclicker-backend-restored/main/monsters/Sprites/Floating%20bBanana.png" },
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
                    { 1, 56f, 4, 8, 4, 1 },
                    { 2, 74f, 4, 3, 1, 2 },
                    { 3, 30f, 4, 5, 3, 3 },
                    { 4, 73f, 3, 5, 3, 3 },
                    { 5, 54f, 1, 2, 1, 4 },
                    { 6, 50f, 3, 4, 1, 4 },
                    { 7, 36f, 4, 5, 4, 5 },
                    { 8, 59f, 1, 5, 1, 6 },
                    { 9, 40f, 2, 5, 2, 7 },
                    { 10, 62f, 4, 4, 2, 7 },
                    { 11, 25f, 2, 3, 2, 8 },
                    { 12, 79f, 2, 3, 1, 9 },
                    { 13, 28f, 3, 8, 4, 10 },
                    { 14, 22f, 4, 6, 4, 11 },
                    { 15, 34f, 1, 6, 3, 11 },
                    { 16, 77f, 2, 7, 4, 12 },
                    { 17, 50f, 1, 2, 1, 12 },
                    { 18, 62f, 2, 5, 1, 13 },
                    { 19, 65f, 4, 4, 3, 13 },
                    { 20, 21f, 2, 3, 1, 14 },
                    { 21, 35f, 1, 4, 1, 15 },
                    { 22, 71f, 3, 5, 4, 15 },
                    { 23, 47f, 2, 7, 3, 16 },
                    { 24, 20f, 2, 5, 3, 17 },
                    { 25, 41f, 4, 5, 2, 17 },
                    { 26, 45f, 2, 7, 4, 18 },
                    { 27, 68f, 4, 5, 2, 19 },
                    { 28, 44f, 4, 5, 1, 20 },
                    { 29, 44f, 3, 4, 1, 20 },
                    { 30, 29f, 3, 5, 1, 21 },
                    { 31, 33f, 4, 4, 2, 22 },
                    { 32, 42f, 1, 4, 2, 23 },
                    { 33, 31f, 3, 5, 3, 24 },
                    { 34, 52f, 2, 8, 4, 24 },
                    { 35, 76f, 4, 3, 2, 25 },
                    { 36, 24f, 2, 7, 3, 26 },
                    { 37, 46f, 1, 5, 1, 27 },
                    { 38, 44f, 3, 3, 2, 28 },
                    { 39, 65f, 2, 2, 1, 28 },
                    { 40, 47f, 2, 8, 4, 29 },
                    { 41, 31f, 1, 5, 1, 29 },
                    { 42, 57f, 3, 4, 1, 30 },
                    { 43, 64f, 4, 4, 3, 30 }
                });

            migrationBuilder.InsertData(
                table: "monster_stats",
                columns: new[] { "id", "basehealth", "extra_health", "gold_drop", "monster_id" },
                values: new object[,]
                {
                    { 1, 10f, 5f, 3, 1 },
                    { 2, 10f, 5f, 3, 2 },
                    { 3, 10f, 7f, 1, 3 },
                    { 4, 10f, 7f, 3, 4 },
                    { 5, 10f, 7f, 3, 5 },
                    { 6, 10f, 6f, 3, 6 },
                    { 7, 10f, 6f, 3, 7 },
                    { 8, 10f, 7f, 4, 8 },
                    { 9, 10f, 5f, 2, 9 },
                    { 10, 10f, 7f, 4, 10 },
                    { 11, 10f, 7f, 2, 11 },
                    { 12, 10f, 5f, 2, 12 },
                    { 13, 10f, 5f, 4, 13 },
                    { 14, 10f, 8f, 3, 14 },
                    { 15, 10f, 8f, 2, 15 },
                    { 16, 10f, 9f, 4, 16 },
                    { 17, 10f, 8f, 4, 17 },
                    { 18, 10f, 7f, 3, 18 },
                    { 19, 10f, 8f, 2, 19 },
                    { 20, 10f, 7f, 4, 20 },
                    { 21, 10f, 6f, 3, 21 },
                    { 22, 10f, 5f, 2, 22 },
                    { 23, 10f, 5f, 3, 23 },
                    { 24, 10f, 6f, 2, 24 },
                    { 25, 10f, 5f, 3, 25 },
                    { 26, 10f, 8f, 3, 26 },
                    { 27, 10f, 8f, 2, 27 },
                    { 28, 10f, 5f, 3, 28 },
                    { 29, 10f, 7f, 3, 29 },
                    { 30, 10f, 5f, 4, 30 }
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
                name: "IX_player_inventory_player_id",
                table: "player_inventory",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "IX_player_stats_user_id",
                table: "player_stats",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_statistic_User",
                table: "user_statistic",
                column: "User");
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
                name: "user_statistic");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "monster");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "player_stats");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
