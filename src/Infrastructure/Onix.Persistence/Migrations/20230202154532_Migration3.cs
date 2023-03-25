using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onix.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyIntegratedApplications",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Users_FirstLastName",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMenu",
                schema: "dbo",
                table: "UserMenu");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationName",
                schema: "dbo",
                table: "CompanyInformations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthenticationType",
                schema: "dbo",
                table: "CompanyInformations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "CompanyInformations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityKey",
                schema: "dbo",
                table: "CompanyInformations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceUrl",
                schema: "dbo",
                table: "CompanyInformations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "dbo",
                table: "CompanyInformations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                schema: "dbo",
                table: "CompanyInformations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMenu",
                schema: "dbo",
                table: "UserMenu",
                column: "Id")
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FirstLastName",
                schema: "dbo",
                table: "Users",
                column: "FirstLastName");

            migrationBuilder.CreateIndex(
                name: "IX_UserMenu_UserId",
                schema: "dbo",
                table: "UserMenu",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FirstLastName",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMenu",
                schema: "dbo",
                table: "UserMenu");

            migrationBuilder.DropIndex(
                name: "IX_UserMenu_UserId",
                schema: "dbo",
                table: "UserMenu");

            migrationBuilder.DropColumn(
                name: "ApplicationName",
                schema: "dbo",
                table: "CompanyInformations");

            migrationBuilder.DropColumn(
                name: "AuthenticationType",
                schema: "dbo",
                table: "CompanyInformations");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "dbo",
                table: "CompanyInformations");

            migrationBuilder.DropColumn(
                name: "SecurityKey",
                schema: "dbo",
                table: "CompanyInformations");

            migrationBuilder.DropColumn(
                name: "ServiceUrl",
                schema: "dbo",
                table: "CompanyInformations");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "dbo",
                table: "CompanyInformations");

            migrationBuilder.DropColumn(
                name: "Username",
                schema: "dbo",
                table: "CompanyInformations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMenu",
                schema: "dbo",
                table: "UserMenu",
                columns: new[] { "UserId", "MenuId" });

            migrationBuilder.CreateTable(
                name: "CompanyIntegratedApplications",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    AuthenticationType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    SecurityKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: ""),
                    Type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValue: ""),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyIntegratedApplications", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_CompanyIntegratedApplications_CompanyInformations_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "CompanyInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FirstLastName",
                schema: "dbo",
                table: "Users",
                column: "FirstLastName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIntegratedApplications_CompanyId",
                schema: "dbo",
                table: "CompanyIntegratedApplications",
                column: "CompanyId");
        }
    }
}
