using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Models;

public class Order
{

    public int ID { get; set; }
    public DateTime OrderDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalPrice { get; set; }

    public int UserID { get; set; }
    public User? User { get; set; }


    public virtual ICollection<CartItem>? CartItems { get; set; }



}