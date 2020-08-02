using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeepeeDotNerf.Models
{
  [Table("client")]
  public class Client
  {
    [Key]
    [Column("client_id")]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string email { get; set; }

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


    public List<Address> Addresses { get; set; }
  }
}
// /**
//  * @ORM\Id()
//  * @ORM\GeneratedValue()
//  * @ORM\Column(type="integer")
//  */
// private $id;

// /**
//  * @ORM\Column(type="string", length=255)
//  * @Assert\Email(
//  *     message = "L'email '{{ value }}' n'est pas valide."
//  * )
//  */
// private $email;

// /**
//  * @ORM\Column(type="datetime")
//  */
// private $createdAt;


// /**
//  * @ORM\OneToMany(targetEntity="App\Entity\Address", mappedBy="client", cascade={"persist", "remove"})
//  * @Assert\All({
//  *        @Assert\Type(type="App\Entity\Address"),
//  * })
//  * @Assert\Valid
//  */
// private $addresses;