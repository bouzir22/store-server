using Microsoft.EntityFrameworkCore;
namespace API.Entities{

public class ApplicationDbContext : DbContext
{
    public DbSet<Produit> produits{get;set;}
    public DbSet<Client> clients{get;set;}
    public DbSet<Magasin> magasins {get;set;}
    public DbSet<Panier> paniers {get;set;}
    public DbSet <Commande> commandes {get;set;}
    public  DbSet<Vendeur>  vendeurs {get;set;}
    public DbSet<PanierProduit> panierProduits{get;set;}
    public DbSet<LigneComamnde> ligneComamndes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Filename=./data.db");
     

    }


}

}