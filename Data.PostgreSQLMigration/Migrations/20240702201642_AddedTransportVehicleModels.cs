using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.PostgreSQLMigration.Migrations
{
    /// <inheritdoc />
    public partial class AddedTransportVehicleModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transports",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    engine_size = table.Column<short>(type: "smallint", nullable: false, defaultValue:"1"),
                    passengers_count = table.Column<short>(type: "smallint", nullable: false, defaultValue:"1"),
                    price = table.Column<int>(type: "integer", nullable: false),
                    model_id = table.Column<short>(type: "smallint", nullable: true),
                    available_level = table.Column<short>(type: "smallint", nullable: false, defaultValue: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transports", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transport_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    boost_level = table.Column<short>(type: "smallint", nullable: false, defaultValue: "0"),
                    engine_size = table.Column<short>(type: "smallint", nullable: false, defaultValue: "1"),
                    passengers_count = table.Column<short>(type: "smallint", nullable: false, defaultValue: "1"),
                    city_id = table.Column<short>(type: "smallint", nullable: true),
                    route_id = table.Column<int>(type: "integer", nullable: true),
                    start_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.id);
                    table.ForeignKey(
                        name: "FK_vehicles_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_vehicles_routes_route_id",
                        column: x => x.route_id,
                        principalTable: "routes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_vehicles_transports_transport_id",
                        column: x => x.transport_id,
                        principalTable: "transports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vehicles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_city_id",
                table: "vehicles",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_route_id",
                table: "vehicles",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_transport_id",
                table: "vehicles",
                column: "transport_id");

            migrationBuilder.CreateIndex(
                name: "ix_vehicles_user_id",
                table: "vehicles",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicles");

            migrationBuilder.DropTable(
                name: "transports");
        }
    }
}
