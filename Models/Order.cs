using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeepeeDotNerf.Models
{
  [Table("order_info")]
  public class Order
  {
    [Key]
    [Column("order_id")]
    public int Id { get; set; }

    [Required]
    [Column("payment_method", TypeName = "varchar(32)")]
    public string paymentMethod { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal total { get; set; }

    [Required]
    [Column("api_order_id")]
    public int ApiOrderId { get; set; }

    [Required]
    [Column("status", TypeName = "varchar(32)")]
    public string status { get; set; }

    [Required]
    [Column("client_id")]
    public int clientForeignKey { get; set; }

    [ForeignKey("clientForeignKey")]
    public Client client { get; set; }

    [Required]
    [Column("product_id")]
    public int productForeignKey { get; set; }

    [ForeignKey("productForeignKey")]
    public Product product { get; set; }

  }
}