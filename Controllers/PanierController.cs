
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers{


[ApiController]
[Route("paniers")]

public class PanierController:ControllerBase{
    private readonly ApplicationDbContext ctx = new ApplicationDbContext();

[HttpPost("{id}")]
public void addproduit (int id, Dictionary<int,int> ps)
{
    //Console.WriteLine("called");
    
    var c = ctx.clients.Find(id);
Panier panier;

if(c!=null){
if (c.PanierId==null){
    c.panier =new Panier();
  
  //  c.panier.produits=new List<Produit>();
    panier=c.panier;
   
Console.WriteLine("created");
Console.WriteLine(c.panier.id);


}else{
  
  
  panier =ctx.paniers.Include(panier =>panier.produits).Where(p=>p.id==c.PanierId).FirstOrDefault();




}



} else throw new Exception("user not found");



  foreach (var kv in ps)
   {
       PanierProduit pp=new PanierProduit();
       Produit produit=ctx.produits.Find(kv.Key);
  pp.panier=panier;
  pp.produit=produit;
      ctx.panierProduits.Add(pp);
      produit.Quantite-=kv.Value;
      ctx.produits.Update(produit);
      
      pp.quantite=kv.Value;
      
       }
c.panier=panier;



          
         //ctx.paniers.Update(panier);
         ctx.clients.Update(c);

          ctx.SaveChanges();
  









}
[HttpDelete("{id}")]
public void viderPanier(int id)
  {Client client =ctx.clients.Include(x=>x.panier).ThenInclude(x=>x.produits). Where(p=>p.ClientId==id).FirstOrDefault();
      
      client.panier.produits.Clear();
        ctx.clients.Update(client);ctx.SaveChanges();
        
        
        
        }

[HttpGet]
public ICollection<Panier> getAll(){
    return ctx.paniers.Include(x=>x.produits).ToList();

}

}

}