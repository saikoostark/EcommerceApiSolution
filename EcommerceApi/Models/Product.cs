using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcommerceApi.Base;

namespace EcommerceApi.Models;

public class Product : ProductBase
{
    public int ID { get; set; }


    public byte[]? Image { get; set; }

    public virtual ICollection<ProductCategory>? ProductCategorys { get; set; }


}
