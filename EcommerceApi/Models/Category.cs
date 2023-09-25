using System.ComponentModel.DataAnnotations;
using EcommerceApi.Base;
namespace EcommerceApi.Models;

public class Category : CategoryBase
{

    public int ID { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<ProductCategory>? ProductCategorys { get; set; }

}
