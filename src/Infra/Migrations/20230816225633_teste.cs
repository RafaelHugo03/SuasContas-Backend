using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    email_address = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    receive_email = table.Column<bool>(type: "bit", nullable: false),
                    is_valid_email = table.Column<bool>(type: "bit", nullable: false),
                    is_premium_user = table.Column<bool>(type: "bit", nullable: false),
                    role = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    installments = table.Column<short>(type: "smallint", nullable: true),
                    last_installment_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bill_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bill_user_id",
                table: "bill",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bill");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
