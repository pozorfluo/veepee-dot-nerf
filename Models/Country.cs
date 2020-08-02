using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeepeeDotNerf.Models
{
  [Table("country")]
  public class Country
  {
    [Key]
    [Column("country_id")]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string name { get; set; }

    public List<Address> Addresses {get; set;}
  }
}