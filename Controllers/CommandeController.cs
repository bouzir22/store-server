using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers{
    public class CommandeController{


       
    private readonly ApplicationDbContext ctx = new ApplicationDbContext();
         [HttpPost("{id}")]
    public void purchase(int id){
        Client client =ctx.clients.Include(x=>x.commandes).Where(p=>p.ClientId==id).FirstOrDefault();
        var panierId= client.PanierId;
         Commande c=new Commande();
         ctx.commandes.Add(c);
    
    
    Panier panier =  ctx.paniers.Include(panier =>panier.produits).ThenInclude(x=>x.produit).
    Where(p=>p.id==panierId).FirstOrDefault();
     
    foreach(PanierProduit pp in panier.produits)
  
    {
        LigneComamnde lc =new LigneComamnde();
        lc.commande=c;
        lc.produit=pp.produit;
        Console.WriteLine("dsdds");
       // Console.WriteLine(c.id);
      //  Console.WriteLine(pp.produit.ProduitID);
        ctx.ligneComamndes.Add(lc);
        }
     client.commandes.Add(c);
     ICollection<PanierProduit> pps= ctx.panierProduits.Where(x=>x.panier.id==panierId).ToList();
     Console.WriteLine(pps.Count());

     ctx.panierProduits.RemoveRange(pps);
  
ctx.SaveChanges();

    }
[HttpGet]
public Client GetCommandes(int clientId)
{Client c = ctx.clients.Include(x => x.commandes).
ThenInclude(x=>x.listProduits).ThenInclude(x =>x.produit).
Where(x=>x.ClientId==clientId)
.FirstOrDefault();
     
  /*ICollection<Commande>
    ICollection<int> clientCmds = this.ctx.clients
    
    return this.ctx.commandes.Where(x =>x.id)
    */
    return c;
    }


}}