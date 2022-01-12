using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers{
[ApiController]
[Route("clients")]

public class ClientController:ControllerBase{
    private readonly ApplicationDbContext ctx = new ApplicationDbContext();
/*
[HttpGet]
public List<Client> getAll(){
return ctx.clients.Include(x=>x.panier).ThenInclude(x=>x.produits).ThenInclude(x =>x.produit)
.Include(c=> c.commandes).ThenInclude(x => x.listProduits)
.ToList();

}*/

[HttpGet]
public Client GetCommandes(int clientId)
{Client c = ctx.clients.Include(x=>x.panier).ThenInclude(x=>x.produits).ThenInclude(x =>x.produit)
.Include(x => x.commandes).
ThenInclude(x=>x.listProduits).ThenInclude(x =>x.produit).
Where(x=>x.ClientId==clientId)
.FirstOrDefault();
     
  /*ICollection<Commande>
    ICollection<int> clientCmds = this.ctx.clients
    
    return this.ctx.commandes.Where(x =>x.id)
    */
    return c;
    }

[HttpPost]
public void create (Client c)
{ctx.clients.Add(c);
ctx.SaveChanges();}

       [HttpDelete]
        public void Delete(int id)
        {
            var p = getOne(id);
            ctx.Remove(p);
            ctx.SaveChanges();
        }


  private Client getOne(int id)
        {
            var c= ctx.clients.Find(id);
            if (c == null) throw new KeyNotFoundException("User not found");
            return c;
        }



}



}