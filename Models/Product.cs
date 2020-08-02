using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeepeeDotNerf.Models
{
  [Table("product")]
  public class Product
  {
    [Column("product_id")]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string sku { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string name { get; set; }

    [Required]
    [MaxLength(500)]
    public string description { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal price { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal msrp { get; set; }

    [Required]
    public int inventory { get; set; } = 0;

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string image { get; set; }

    [Required]
    public bool hot { get; set; } = false;

    [Required]
    [Display(Name = "created")]
    [Column("created_at")]
    [DataType(DataType.Date)]
    public DateTime createdAt { get; set; }

    [Required]
    [Display(Name = "updated")]
    [Column("updated_at")]
    [DataType(DataType.Date)]
    public DateTime updatedAt { get; set; }
  }
}
//  /**
//      * @ORM\Id()
//      * @ORM\GeneratedValue()
//      * @ORM\Column(type="integer")
//      */
//     private $id;

//     /**
//      * @ORM\Column(type="string", length=255)
//      */
//     private $sku;

//     /**
//      * @ORM\Column(type="string", length=255)
//      */
//     private $name;

//     /**
//      * @ORM\Column(type="text", nullable=true)
//      */
//     private $description;

//     /**
//      * @ORM\Column(type="integer")
//      */
//     private $price;

//     /**
//      * @ORM\Column(type="integer")
//      */
//     private $msrp;

//     /**
//      * @ORM\Column(type="integer")
//      */
//     private $inventory;

//     /**
//      * @ORM\Column(type="string", length=255, nullable=true)
//      */
//     private $image;

//     /**
//      * @ORM\Column(type="boolean")
//      */
//     private $hot;