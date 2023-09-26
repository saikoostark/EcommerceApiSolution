using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EcommerceApi.Base;

namespace EcommerceApi.DTO;

public class UserDTOS : UserBase
{
    [Key]
    public int ID { get; set; }

}

public class UserDTOR : UserBase
{


    [Required]
    [PasswordPropertyText]
    public string? Password { get; set; }


    [Required]
    [PasswordPropertyText]
    public string? ConfirmPassword { get; set; }

}

public class LoginUser
{

    [Required]
    public string? UserNameOrEmail { get; set; }


    [Required]
    [PasswordPropertyText]
    public string? Password { get; set; }


    public bool RememberMe { get; set; }


}

