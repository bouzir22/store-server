using System.Text.Json.Serialization;

namespace API.Entities{

public class Produit{

public int ProduitID {get;set;}
public string Designation {get;set;}
public double Prix {get;set;}
public int Quantite {get;set;}
 [JsonIgnore]
public ICollection<PanierProduit>? paniers{get;set;}
 [JsonIgnore]
public ICollection<LigneComamnde>? commandes{get;set;}


}


}