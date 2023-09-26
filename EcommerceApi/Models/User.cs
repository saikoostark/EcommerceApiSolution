using System.ComponentModel.DataAnnotations;
using EcommerceApi.Base;

namespace EcommerceApi.Models;

public class User : UserBase
{
    [Key]
    public int ID { get; set; }

    public string? Salt { get; set; }

    [Required]
    public string? HashedPassword { get; set; }

    [Required]
    public string? Role { get; set; }


    public virtual ICollection<Order>? Orders { get; set; }

}