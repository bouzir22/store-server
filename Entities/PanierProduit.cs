using System.Text.Json.Serialization;

namespace API.Entities{

public class PanierProduit{

public int id {get;set;}
public int quantite{get;set;}
public int IdProduit;
[JsonIgnore]
public Panier panier{get;set;}
public int IdPanier;

public Produit produit{get;set;}





}









}