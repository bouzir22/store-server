namespace API.Entities{public class Commande{

public int id {get;set;}
public DateTime date {get;set;}

public ICollection <LigneComamnde> listProduits {get;set;}

}}