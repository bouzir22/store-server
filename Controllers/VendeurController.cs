using System.Linq;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers{
    
    
    [ApiController]
[Route("vendeurs")]
    public class VendeurController: ControllerBase{

    private readonly ApplicationDbContext ctx = new ApplicationDbContext();
[HttpGet]
public List<Vendeur> getAll(){
return ctx.vendeurs.ToList<Vendeur>();

}
[HttpPost]
public void create (Vendeur v)
{
    //v.magasin=new Magasin();
    ctx.vendeurs. Add(v);
ctx.SaveChanges();}

       [HttpDelete]
        public void Delete(int id)
        {
            var v =getVendeur(id);
            ctx.Remove(v);
            ctx.SaveChanges();
        }

       [HttpGet("vendeur/{id}")]
  public Vendeur getVendeur(int id)
        {
            var v= ctx.vendeurs.Include(v=>v.magasin).ThenInclude(x=>x.produits).Where(v=>v.id==id).FirstOrDefault();
            if (v== null) throw new KeyNotFoundException("User not found");
            return v;
        }


}



    }
    
    
    
    