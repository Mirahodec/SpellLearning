using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "spells",
                columns: table => new
                {
                    spell_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    cost_currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true, defaultValueSql: "'click'::character varying"),
                    rarity = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, defaultValueSql: "'обычная'::character varying"),
                    cost_amount = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "0"),
                    image_url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    game_effect_code = table.Column<string>(type: "text", nullable: true),
                    base_damage = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spells", x => x.spell_id);
                });

            migrationBuilder.CreateTable(
                name: "user_upgrades",
                columns: table => new
                {
                    upgrade_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    cost_click = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "0"),
                    power_multiplier = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true, defaultValueSql: "1.0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_upgrades_pkey", x => x.upgrade_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    last_login = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    currency_click = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "0"),
                    currency_game = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "gacha_pulls",
                columns: table => new
                {
                    pull_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    spell_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    pull_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("gacha_pulls_pkey", x => x.pull_id);
                    table.ForeignKey(
                        name: "gacha_pulls_spell_id_fkey",
                        column: x => x.spell_id,
                        principalTable: "spells",
                        principalColumn: "spell_id");
                    table.ForeignKey(
                        name: "gacha_pulls_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "user_clicker_upgrades",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    upgrade_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "1"),
                    purchased_last = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_clicker_upgrades_pkey", x => new { x.user_id, x.upgrade_id });
                    table.ForeignKey(
                        name: "user_clicker_upgrades_upgrade_id_fkey",
                        column: x => x.upgrade_id,
                        principalTable: "user_upgrades",
                        principalColumn: "upgrade_id");
                    table.ForeignKey(
                        name: "user_clicker_upgrades_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "user_decks",
                columns: table => new
                {
                    deck_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    deck_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_decks_pkey", x => x.deck_id);
                    table.ForeignKey(
                        name: "user_decks_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "user_inventory",
                columns: table => new
                {
                    inventory_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    spell_id = table.Column<int>(type: "integer", nullable: false),
                    obtained_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_inventory_pkey", x => x.inventory_id);
                    table.ForeignKey(
                        name: "user_inventory_spell_id_fkey",
                        column: x => x.spell_id,
                        principalTable: "spells",
                        principalColumn: "spell_id");
                    table.ForeignKey(
                        name: "user_inventory_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "game_saves",
                columns: table => new
                {
                    save_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "1"),
                    high_score = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "0"),
                    equipped_deck_id = table.Column<int>(type: "integer", nullable: true),
                    save_data = table.Column<string>(type: "text", nullable: true),
                    last_updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("game_saves_pkey", x => x.save_id);
                    table.ForeignKey(
                        name: "game_saves_equipped_deck_id_fkey",
                        column: x => x.equipped_deck_id,
                        principalTable: "user_decks",
                        principalColumn: "deck_id");
                    table.ForeignKey(
                        name: "game_saves_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "deck_slots",
                columns: table => new
                {
                    slot_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    deck_id = table.Column<int>(type: "integer", nullable: false),
                    inventory_id = table.Column<int>(type: "integer", nullable: false),
                    slot_number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("deck_slots_pkey", x => x.slot_id);
                    table.ForeignKey(
                        name: "deck_slots_deck_id_fkey",
                        column: x => x.deck_id,
                        principalTable: "user_decks",
                        principalColumn: "deck_id");
                    table.ForeignKey(
                        name: "deck_slots_inventory_id_fkey",
                        column: x => x.inventory_id,
                        principalTable: "user_inventory",
                        principalColumn: "inventory_id");
                });

            migrationBuilder.CreateTable(
                name: "traces",
                columns: table => new
                {
                    trade_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id_offer = table.Column<int>(type: "integer", nullable: false),
                    user_id_receive = table.Column<int>(type: "integer", nullable: false),
                    inventory_id_offer = table.Column<int>(type: "integer", nullable: false),
                    inventory_id_want = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true, defaultValueSql: "'ожидание'::character varying"),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    resolved_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("traces_pkey", x => x.trade_id);
                    table.ForeignKey(
                        name: "traces_inventory_id_offer_fkey",
                        column: x => x.inventory_id_offer,
                        principalTable: "user_inventory",
                        principalColumn: "inventory_id");
                    table.ForeignKey(
                        name: "traces_inventory_id_want_fkey",
                        column: x => x.inventory_id_want,
                        principalTable: "user_inventory",
                        principalColumn: "inventory_id");
                    table.ForeignKey(
                        name: "traces_user_id_offer_fkey",
                        column: x => x.user_id_offer,
                        principalTable: "users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "traces_user_id_receive_fkey",
                        column: x => x.user_id_receive,
                        principalTable: "users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "idx_deck_slots_deck_id",
                table: "deck_slots",
                column: "deck_id");

            migrationBuilder.CreateIndex(
                name: "IX_deck_slots_inventory_id",
                table: "deck_slots",
                column: "inventory_id");

            migrationBuilder.CreateIndex(
                name: "idx_gacha_pulls_spell_id",
                table: "gacha_pulls",
                column: "spell_id");

            migrationBuilder.CreateIndex(
                name: "idx_gacha_pulls_user_id",
                table: "gacha_pulls",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_game_saves_user_id",
                table: "game_saves",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_game_saves_equipped_deck_id",
                table: "game_saves",
                column: "equipped_deck_id");

            migrationBuilder.CreateIndex(
                name: "idx_traces_user_offer",
                table: "traces",
                column: "user_id_offer");

            migrationBuilder.CreateIndex(
                name: "idx_traces_user_receive",
                table: "traces",
                column: "user_id_receive");

            migrationBuilder.CreateIndex(
                name: "IX_traces_inventory_id_offer",
                table: "traces",
                column: "inventory_id_offer");

            migrationBuilder.CreateIndex(
                name: "IX_traces_inventory_id_want",
                table: "traces",
                column: "inventory_id_want");

            migrationBuilder.CreateIndex(
                name: "IX_user_clicker_upgrades_upgrade_id",
                table: "user_clicker_upgrades",
                column: "upgrade_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_decks_user_id",
                table: "user_decks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_user_inventory_spell_id",
                table: "user_inventory",
                column: "spell_id");

            migrationBuilder.CreateIndex(
                name: "idx_user_inventory_user_id",
                table: "user_inventory",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "idx_users_email",
                table: "users",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "idx_users_username",
                table: "users",
                column: "username");

            migrationBuilder.CreateIndex(
                name: "users_email_key",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_username_key",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deck_slots");

            migrationBuilder.DropTable(
                name: "gacha_pulls");

            migrationBuilder.DropTable(
                name: "game_saves");

            migrationBuilder.DropTable(
                name: "traces");

            migrationBuilder.DropTable(
                name: "user_clicker_upgrades");

            migrationBuilder.DropTable(
                name: "user_decks");

            migrationBuilder.DropTable(
                name: "user_inventory");

            migrationBuilder.DropTable(
                name: "user_upgrades");

            migrationBuilder.DropTable(
                name: "spells");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
