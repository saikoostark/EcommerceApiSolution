using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EcommerceApi.Base;

namespace EcommerceApi.DTO;

public class UserDTOS : UserBase
{
    public virtual ICollection<int>? Orders { get; set; }
}

public class UserDTOR
{

    [Required]
    public string? UserNameOrEmail { get; set; }


    [Required]
    [PasswordPropertyText]
    public string? Password { get; set; }


}
