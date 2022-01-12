using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "magasins",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_magasins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "paniers",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paniers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produits",
                columns: table => new
                {
                    ProduitID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Designation = table.Column<string>(type: "TEXT", nullable: false),
                    Prix = table.Column<double>(type: "REAL", nullable: false),
                    Quantite = table.Column<int>(type: "INTEGER", nullable: false),
                    Magasinid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produits", x => x.ProduitID);
                    table.ForeignKey(
                        name: "FK_produits_magasins_Magasinid",
                        column: x => x.Magasinid,
                        principalTable: "magasins",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "vendeurs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    magasinid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendeurs", x => x.id);
                    table.ForeignKey(
                        name: "FK_vendeurs_magasins_magasinid",
                        column: x => x.magasinid,
                        principalTable: "magasins",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    PanierId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_clients_paniers_PanierId",
                        column: x => x.PanierId,
                        principalTable: "paniers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "panierProduits",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quantite = table.Column<int>(type: "INTEGER", nullable: false),
                    panierid = table.Column<int>(type: "INTEGER", nullable: false),
                    ProduitID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_panierProduits", x => x.id);
                    table.ForeignKey(
                        name: "FK_panierProduits_paniers_panierid",
                        column: x => x.panierid,
                        principalTable: "paniers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_panierProduits_produits_ProduitID",
                        column: x => x.ProduitID,
                        principalTable: "produits",
                        principalColumn: "ProduitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commandes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commandes", x => x.id);
                    table.ForeignKey(
                        name: "FK_commandes_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "ClientId");
                });

            migrationBuilder.CreateTable(
                name: "ligneComamndes",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCommande = table.Column<int>(type: "INTEGER", nullable: false),
                    commandeid = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProduit = table.Column<int>(type: "INTEGER", nullable: false),
                    ProduitID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ligneComamndes", x => x.id);
                    table.ForeignKey(
                        name: "FK_ligneComamndes_commandes_commandeid",
                        column: x => x.commandeid,
                        principalTable: "commandes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ligneComamndes_produits_ProduitID",
                        column: x => x.ProduitID,
                        principalTable: "produits",
                        principalColumn: "ProduitID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_PanierId",
                table: "clients",
                column: "PanierId");

            migrationBuilder.CreateIndex(
                name: "IX_commandes_ClientId",
                table: "commandes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ligneComamndes_commandeid",
                table: "ligneComamndes",
                column: "commandeid");

            migrationBuilder.CreateIndex(
                name: "IX_ligneComamndes_ProduitID",
                table: "ligneComamndes",
                column: "ProduitID");

            migrationBuilder.CreateIndex(
                name: "IX_panierProduits_panierid",
                table: "panierProduits",
                column: "panierid");

            migrationBuilder.CreateIndex(
                name: "IX_panierProduits_ProduitID",
                table: "panierProduits",
                column: "ProduitID");

            migrationBuilder.CreateIndex(
                name: "IX_produits_Magasinid",
                table: "produits",
                column: "Magasinid");

            migrationBuilder.CreateIndex(
                name: "IX_vendeurs_magasinid",
                table: "vendeurs",
                column: "magasinid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ligneComamndes");

            migrationBuilder.DropTable(
                name: "panierProduits");

            migrationBuilder.DropTable(
                name: "vendeurs");

            migrationBuilder.DropTable(
                name: "commandes");

            migrationBuilder.DropTable(
                name: "produits");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "magasins");

            migrationBuilder.DropTable(
                name: "paniers");
        }
    }
}
