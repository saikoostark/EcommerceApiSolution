using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Models;

public class User
{
    

    public string? Salt { get; set; }

    [Required]
    public string? HashedPassword { get; set; }


    public virtual ICollection<Order>? Orders { get; set; }

}