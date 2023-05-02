using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarvelEntity.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "blobs",
                schema: "public",
                columns: table => new
                {
                    blob_id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    mime = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("blob_pkey", x => x.blob_id);
                });

            migrationBuilder.CreateTable(
                name: "theater_types",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_theater_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cinemas",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    blob_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cinema_pkey", x => x.id);
                    table.ForeignKey(
                        name: "u__blob_id_fkey",
                        column: x => x.blob_id,
                        principalSchema: "public",
                        principalTable: "blobs",
                        principalColumn: "blob_id");
                });

            migrationBuilder.CreateTable(
                name: "theaters",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    cinema_id = table.Column<string>(type: "text", nullable: false),
                    theater_type_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("theater_pkey", x => x.id);
                    table.ForeignKey(
                        name: "t__theater_fkey",
                        column: x => x.cinema_id,
                        principalSchema: "public",
                        principalTable: "cinemas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "t__theatertype_id_fkey",
                        column: x => x.theater_type_id,
                        principalSchema: "public",
                        principalTable: "theater_types",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_cinemas_blob_id",
                schema: "public",
                table: "cinemas",
                column: "blob_id");

            migrationBuilder.CreateIndex(
                name: "ix_theaters_cinema_id",
                schema: "public",
                table: "theaters",
                column: "cinema_id");

            migrationBuilder.CreateIndex(
                name: "ix_theaters_theater_type_id",
                schema: "public",
                table: "theaters",
                column: "theater_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "theaters",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cinemas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "theater_types",
                schema: "public");

            migrationBuilder.DropTable(
                name: "blobs",
                schema: "public");
        }
    }
}
