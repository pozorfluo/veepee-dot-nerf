using System;
using System.ComponentModel.DataAnnotations;

namespace VeepeeDotNerf.Models
{
    public class Client
    {
    public int Id {get; set;}
    public string firstName {get; set;}
    public string lastName {get; set;}
    public string email {get; set;}

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