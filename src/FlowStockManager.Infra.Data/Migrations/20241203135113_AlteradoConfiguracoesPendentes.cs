using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowStockManager.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlteradoConfiguracoesPendentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Pedidos_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_produto_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clients_ClientId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "pedidos");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                newName: "pedidoproduto");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ClientId",
                table: "pedidos",
                newName: "IX_pedidos_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductId",
                table: "pedidoproduto",
                newName: "IX_pedidoproduto_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedidos",
                table: "pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedidoproduto",
                table: "pedidoproduto",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_pedidoproduto_pedidos_OrderId",
                table: "pedidoproduto",
                column: "OrderId",
                principalTable: "pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidoproduto_produto_ProductId",
                table: "pedidoproduto",
                column: "ProductId",
                principalTable: "produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedidos_Clients_ClientId",
                table: "pedidos",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedidoproduto_pedidos_OrderId",
                table: "pedidoproduto");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidoproduto_produto_ProductId",
                table: "pedidoproduto");

            migrationBuilder.DropForeignKey(
                name: "FK_pedidos_Clients_ClientId",
                table: "pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedidos",
                table: "pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pedidoproduto",
                table: "pedidoproduto");

            migrationBuilder.RenameTable(
                name: "pedidos",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "pedidoproduto",
                newName: "OrderProducts");

            migrationBuilder.RenameIndex(
                name: "IX_pedidos_ClientId",
                table: "Pedidos",
                newName: "IX_Pedidos_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_pedidoproduto_ProductId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Pedidos_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_produto_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clients_ClientId",
                table: "Pedidos",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
