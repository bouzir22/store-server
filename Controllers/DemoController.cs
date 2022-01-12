using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers{
[ApiController]
[Route("products")]
public class DemoController : ControllerBase {
    private readonly ApplicationDbContext ctx = new ApplicationDbContext();
[HttpGet]
public List<Produit> getAll(){
return ctx.produits.ToList<Produit>();

}
[HttpPost]
public void create (Produit p)
{ctx.produits.Add(p);
ctx.SaveChanges();}

[HttpPost ("vendeur/{id}")]
public void addToStore (Produit p ,int id)
{ Vendeur v=ctx.vendeurs.Include(v=>v.magasin).ThenInclude(x=>x.produits).Where(x=>x.id==id).FirstOrDefault();
        v.magasin.produits.Add(p);
    //ctx.produits.Add(p);
ctx.SaveChanges();



}




       [HttpDelete]
        public void Delete(int id)
        {
            var p = getProduit(id);
            ctx.Remove(p);
            ctx.SaveChanges();
        }


  private Produit getProduit(int id)
        {
            var p = ctx.produits.Find(id);
            if (p == null) throw new KeyNotFoundException("User not found");
            return p;
        }


}

}