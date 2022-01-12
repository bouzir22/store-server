using System.ComponentModel.DataAnnotations;

namespace API.Entities{
public class Client{

public int ClientId {get;set;}
public string firstName {get;set;}
public string lastName {get;set;}
public string username {get;set;}
public string password {get;set;}
public string phone {get;set;}
public int? PanierId{get;set;}
public virtual Panier? panier {get;set;}
public ICollection<Commande>? commandes {get;set;}



}



}