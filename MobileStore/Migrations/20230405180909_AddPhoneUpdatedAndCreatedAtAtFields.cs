﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileStore.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneUpdatedAndCreatedAtAtFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Phones",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Phones",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Phones");
        }
    }
}
