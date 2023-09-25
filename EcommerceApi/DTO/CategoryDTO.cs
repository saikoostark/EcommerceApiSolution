using EcommerceApi.Base;

namespace EcommerceApi.DTO;

public class CategoryDTOS : CategoryBase
{
    public int ID { get; set; }

    public string? Image { get; set; }

}

public class CategoryDTOR : CategoryBase
{

    public IFormFile? Image { get; set; }

}
