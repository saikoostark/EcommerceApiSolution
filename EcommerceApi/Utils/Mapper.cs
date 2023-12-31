using EcommerceApi.DTO;
using EcommerceApi.Models;

namespace EcommerceApi.Utils;

public class Mapper
{

    // mappers for category
    public static T? Map<T>(Category? from) where T : CategoryDTOS?, new()
    {
        if (from == null)
            return null;

        T data = new()
        {
            ID = from.ID,
            Name = from.Name,
            Image = Image.ByteArrayToSrc(from.Image)
        };
        return data;
    }


    public static T? Map<T>(CategoryDTOR? from) where T : Category?, new()
    {
        if (from == null)
            return null;

        T data = new()
        {
            Name = from.Name,
            Image = Image.IFormFileToByteArray(from.Image)
        };
        return data;
    }



    // mappers for Product
    public static T? Map<T>(Product? from) where T : ProductDTOS?, new()
    {
        if (from == null)
            return null;

        T data = new()
        {
            ID = from.ID,
            Name = from.Name,
            Image = Image.ByteArrayToSrc(from.Image),
            Description = from.Description,
            Price = from.Price,
            DiscountPercentage = from.DiscountPercentage,
            Quantity = from.Quantity,
            Categories = new HashSet<int>()
        };

        if (from.ProductCategorys != null)
        {
            foreach (var cat in from.ProductCategorys)
                data.Categories.Add(cat.CategoryID);

        }
        return data;
    }


    public static T? Map<T>(ProductDTOR? from) where T : Product?, new()
    {
        if (from == null)
            return null;

        T data = new()
        {
            Name = from.Name,
            Image = Image.IFormFileToByteArray(from.Image),
            Description = from.Description,
            Price = from.Price,
            DiscountPercentage = from.DiscountPercentage,
            Quantity = from.Quantity,
        };

        return data;
    }






    public static T? Map<T>(User? from) where T : UserDTOS?, new()
    {
        if (from == null)
            return null;

        T data = new()
        {
            ID = from.ID,
            UserName = from.UserName,
            Email = from.Email,
            Phone = from.Phone,
            Address = from.Address
        };
        return data;
    }


    public static T? Map<T>(UserDTOR? from) where T : User?, new()
    {
        if (from == null || from.Password == null || from.ConfirmPassword == null || from.Password != from.ConfirmPassword)
            return null;

        string salt = Hasher.GenerateSalt();
        T data = new()
        {
            UserName = from.UserName,
            Email = from.Email,
            Phone = from.Phone,
            Address = from.Address,
            Salt = salt,
            HashedPassword = Hasher.GenerateHash(from.Password, salt),
            Role = UserUtiles.UserRole
        };
        return data;
    }
}
