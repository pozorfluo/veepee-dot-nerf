using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeepeeDotNerf.Models
{
  [Table("address")]
  public class Address
  {
    [Key]
    [Column("address_id")]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(32)")]
    public string type { get; set; }

    [Required]
    [Display(Name = "first name")]
    [Column("first_name", TypeName = "varchar(255)")]
    public string firstName { get; set; }

    [Required]
    [Display(Name = "last name")]
    [Column("last_name", TypeName = "varchar(255)")]
    public string lastName { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string email { get; set; }

    [Required]
    [Display(Name = "address")]
    [Column(TypeName = "varchar(255)")]
    public string line1 { get; set; }

    [Required]
    [Display(Name = "address complement")]
    [Column(TypeName = "varchar(255)")]
    public string line2 { get; set; }

    [Required]
    [Column(TypeName = "varchar(255)")]
    public string city { get; set; }

    [Required]
    [Display(Name = "zip code")]
    [Column("zip_code", TypeName = "varchar(255)")]
    public string zipCode { get; set; }

    [Required]
    [Column(TypeName = "varchar(32)")]
    public string phone { get; set; }

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

    [Column("country_id")]
    public int countryForeignKey { get; set; }

    [Required]
    [ForeignKey("countryForeignKey")]
    public Country country { get; set; }

    [Column("client_id")]
    public int clientForeignKey { get; set; }

    [ForeignKey("clientForeignKey")]
    public Client client { get; set; }

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
//  * @Assert\NotBlank(
//  *     message="Votre prénom ne peut être vide."
//  * )
//  * @Assert\Regex(
//  *     pattern="/\d/",
//  *     match=false,
//  *     message="Votre prénom ne peut pas contenir de chiffre."
//  * )
//  * 
//  * pattern="/^['\-\pL][\s'\-\pL]+/",
//  */
// private $firstName;

// /**
//  * @ORM\Column(type="string", length=255)
//  * @Assert\NotBlank(
//  *     message="Votre nom ne peut être vide."
//  * )
//  * @Assert\Regex(
//  *     pattern="/\d/",
//  *     match=false,
//  *     message="Votre nom ne peut pas contenir de chiffre."
//  * )
//  * pattern="/^['\-\pL][\s'\-\pL]+/",
//  */
// private $lastName;

// /**
//  * @ORM\Column(type="string", length=255)
//  * @Assert\NotBlank(
//  *     message="Votre addresse ne peut être vide."
//  * )
//  */
// private $address;

// /**
//  * @ORM\Column(type="string", length=255, nullable=true)
//  */
// private $addressComplement;

// /**
//  * @ORM\Column(type="string", length=255)
//  * @Assert\NotBlank(
//  *     message="Votre ville ne peut être vide."
//  * )
//  */
// private $city;

// /**
//  * @ORM\Column(type="string", length=255)
//  * @Assert\NotBlank(
//  *     message="Votre code postal ne peut être vide."
//  * )
//  */
// private $zipCode;

// /**
//  * @ORM\ManyToOne(targetEntity=Country::class)
//  * @ORM\JoinColumn(nullable=false)
//  * @Assert\NotBlank(
//  *     message="Votre pays ne peut être vide."
//  * )
//  */
// private $country;

// /**
//  * @ORM\Column(type="string", length=255)
//  * @Assert\NotBlank(
//  *     message="Votre téléphone ne peut être vide."
//  * )
//  */
// private $phone;

// /**
//  * @ORM\ManyToOne(targetEntity="App\Entity\Client", inversedBy="addresses")
//  */
// private $client;

// /**
//  * @ORM\Column(type="string", length=255)
//  */
// private $type;