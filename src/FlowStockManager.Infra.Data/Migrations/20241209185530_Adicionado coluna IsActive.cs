﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowStockManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionadocolunaIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clients");
        }
    }
}
