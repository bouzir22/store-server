namespace API.Entities{
    
    
    
public class Panier{

public int id {get;set;}
public ICollection<PanierProduit> produits {get;set;}


}}