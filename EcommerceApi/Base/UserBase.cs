using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Base;

public class UserBase
{
    [Key]
    public int ID { get; set; }

    [Required]
    public string? UserName { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Phone { get; set; }

    [Required]
    public string? Address { get; set; }

    [Required]
    public string? Role { get; set; }
}
