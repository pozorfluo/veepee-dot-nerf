using System;
using System.ComponentModel.DataAnnotations;

namespace veepee_dot_nerf.Models
{
    public class Client
    {
    public int Id {get; set;}
    public string firstName {get; set;}
    public string lastName {get; set;}
    public string email {get; set;}
    public string address {get; set;}
    public string addressComplement {get; set;}
    public string city {get; set;}
    public string zipCode {get; set;}
    // public string -> country {get; set;}
    public string phone {get; set;}
    // public string -> deliveryAddress {get; set;}
    [DataType(DataType.Date)]
    public DateTime createdAt {get; set;}

    }
}