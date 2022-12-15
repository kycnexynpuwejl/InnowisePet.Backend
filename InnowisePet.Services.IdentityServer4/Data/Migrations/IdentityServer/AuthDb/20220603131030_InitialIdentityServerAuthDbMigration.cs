﻿#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace InnowisePet.IdentityServer4.Data.Migrations.IdentityServer.AuthDb;

public partial class InitialIdentityServerAuthDbMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Roles",
            table => new
            {
                Id = table.Column<string>("TEXT", nullable: false),
                Name = table.Column<string>("TEXT", maxLength: 256, nullable: true),
                NormalizedName = table.Column<string>("TEXT", maxLength: 256, nullable: true),
                ConcurrencyStamp = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table => { table.PrimaryKey("PK_Roles", x => x.Id); });

        migrationBuilder.CreateTable(
            "Users",
            table => new
            {
                Id = table.Column<string>("TEXT", nullable: false),
                FirstName = table.Column<string>("TEXT", nullable: true),
                LastName = table.Column<string>("TEXT", nullable: true),
                UserName = table.Column<string>("TEXT", maxLength: 256, nullable: true),
                NormalizedUserName = table.Column<string>("TEXT", maxLength: 256, nullable: true),
                Email = table.Column<string>("TEXT", maxLength: 256, nullable: true),
                NormalizedEmail = table.Column<string>("TEXT", maxLength: 256, nullable: true),
                EmailConfirmed = table.Column<bool>("INTEGER", nullable: false),
                PasswordHash = table.Column<string>("TEXT", nullable: true),
                SecurityStamp = table.Column<string>("TEXT", nullable: true),
                ConcurrencyStamp = table.Column<string>("TEXT", nullable: true),
                PhoneNumber = table.Column<string>("TEXT", nullable: true),
                PhoneNumberConfirmed = table.Column<bool>("INTEGER", nullable: false),
                TwoFactorEnabled = table.Column<bool>("INTEGER", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>("TEXT", nullable: true),
                LockoutEnabled = table.Column<bool>("INTEGER", nullable: false),
                AccessFailedCount = table.Column<int>("INTEGER", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

        migrationBuilder.CreateTable(
            "RoleClaims",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                RoleId = table.Column<string>("TEXT", nullable: false),
                ClaimType = table.Column<string>("TEXT", nullable: true),
                ClaimValue = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RoleClaims", x => x.Id);
                table.ForeignKey(
                    "FK_RoleClaims_Roles_RoleId",
                    x => x.RoleId,
                    "Roles",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserClaims",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                UserId = table.Column<string>("TEXT", nullable: false),
                ClaimType = table.Column<string>("TEXT", nullable: true),
                ClaimValue = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserClaims", x => x.Id);
                table.ForeignKey(
                    "FK_UserClaims_Users_UserId",
                    x => x.UserId,
                    "Users",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserLogins",
            table => new
            {
                LoginProvider = table.Column<string>("TEXT", nullable: false),
                ProviderKey = table.Column<string>("TEXT", nullable: false),
                ProviderDisplayName = table.Column<string>("TEXT", nullable: true),
                UserId = table.Column<string>("TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                table.ForeignKey(
                    "FK_UserLogins_Users_UserId",
                    x => x.UserId,
                    "Users",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserRoles",
            table => new
            {
                UserId = table.Column<string>("TEXT", nullable: false),
                RoleId = table.Column<string>("TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                table.ForeignKey(
                    "FK_UserRoles_Roles_RoleId",
                    x => x.RoleId,
                    "Roles",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_UserRoles_Users_UserId",
                    x => x.UserId,
                    "Users",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "UserTokens",
            table => new
            {
                UserId = table.Column<string>("TEXT", nullable: false),
                LoginProvider = table.Column<string>("TEXT", nullable: false),
                Name = table.Column<string>("TEXT", nullable: false),
                Value = table.Column<string>("TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                table.ForeignKey(
                    "FK_UserTokens_Users_UserId",
                    x => x.UserId,
                    "Users",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            "Roles",
            new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            new object[]
            {
                "d2f1d6e8-7372-4632-8a34-5ec108d60744", "aa185422-6b70-477f-b49e-fd289e7763d7", "Administrator",
                "ADMINISTRATOR"
            });

        migrationBuilder.InsertData(
            "Roles",
            new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            new object[]
            {
                "dc3cc7b3-4de1-4861-b9f0-02b658827e47", "c5906923-f9e6-4d5b-a775-0060df3c134f", "Customer", "CUSTOMER"
            });

        migrationBuilder.CreateIndex(
            "IX_RoleClaims_RoleId",
            "RoleClaims",
            "RoleId");

        migrationBuilder.CreateIndex(
            "RoleNameIndex",
            "Roles",
            "NormalizedName",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_UserClaims_UserId",
            "UserClaims",
            "UserId");

        migrationBuilder.CreateIndex(
            "IX_UserLogins_UserId",
            "UserLogins",
            "UserId");

        migrationBuilder.CreateIndex(
            "IX_UserRoles_RoleId",
            "UserRoles",
            "RoleId");

        migrationBuilder.CreateIndex(
            "EmailIndex",
            "Users",
            "NormalizedEmail");

        migrationBuilder.CreateIndex(
            "UserNameIndex",
            "Users",
            "NormalizedUserName",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "RoleClaims");

        migrationBuilder.DropTable(
            "UserClaims");

        migrationBuilder.DropTable(
            "UserLogins");

        migrationBuilder.DropTable(
            "UserRoles");

        migrationBuilder.DropTable(
            "UserTokens");

        migrationBuilder.DropTable(
            "Roles");

        migrationBuilder.DropTable(
            "Users");
    }
}