using EcommerceApi.Base;

namespace EcommerceApi.DTO;

public class ProductDTOS : ProductBase
{
    public int ID { get; set; }
    public string? Image { get; set; }
    virtual public ICollection<int>? Categories { get; set; }
}

public class ProductDTOR : ProductBase
{

    public IFormFile? Image { get; set; }
    virtual public ICollection<int>? Categories { get; set; }


}
