using System.Text.Json.Serialization;

namespace API.Entities{

public class LigneComamnde{
public int id { get; set; }
public int IdCommande { get; set; }
 [JsonIgnore]
public Commande commande { get; set; }
public int IdProduit {get;set;}

public Produit produit { get; set; }

}


}