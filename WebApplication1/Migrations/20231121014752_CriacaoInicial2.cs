using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.AddColumn<int>(
                name: "ItemPedidoId",
                table: "Pedido",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deposito",
                columns: table => new
                {
                    DepositoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposito", x => x.DepositoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ItemPedidoId",
                table: "Pedido",
                column: "ItemPedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_ItemPedido_ItemPedidoId",
                table: "Pedido",
                column: "ItemPedidoId",
                principalTable: "ItemPedido",
                principalColumn: "ItemPedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_ItemPedido_ItemPedidoId",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "Deposito");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ItemPedidoId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ItemPedidoId",
                table: "Pedido");

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantidade = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.EstoqueId);
                });
        }
    }
}
