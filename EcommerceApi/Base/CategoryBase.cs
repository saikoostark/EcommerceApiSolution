using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Base;

public class CategoryBase
{

    [Required]
    [MaxLength(40)]
    public string? Name { get; set; }
}
