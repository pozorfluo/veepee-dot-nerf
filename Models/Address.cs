using System;
using System.ComponentModel.DataAnnotations;

namespace VeepeeDotNerf.Models
{
    public class Address
    {
        
    public int Id {get; set;}
    public string type{get; set;}
    public string firstName {get; set;}
    public string lastName {get; set;}
    public string email {get; set;}
    public string line1 {get; set;}
    public string line2 {get; set;}
    public string city {get; set;}
    public string zipCode {get; set;}
    public string country {get; set;}
    public string phone {get; set;}

    [DataType(DataType.Date)]
    public DateTime createdAt {get; set;}

    [DataType(DataType.Date)]
    public DateTime updatedAt {get; set;}

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