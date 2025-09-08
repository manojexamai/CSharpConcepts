using System.Xml.Serialization;

namespace Demo_DemoDbMVCWithAuth.Models;


public class Category
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }



    [Display(Name = "Category Name")]
    [Required(ErrorMessage = "{0} cannot be empty")]
    [MaxLength(50, ErrorMessage = "{0} cannot have more than {1} characters")]
    public string CategoryName { get; set; } = string.Empty;                // DEFAULT is NVARCHAR


    //private string _name;
    //public string Name
    //{
    //    set
    //    {
    //        if(value.Length > 50)
    //        {
    //            throw new InvalidDataException( "Name cannot be greater than 50 characters" );
    //        }
    //        _name = value;
    //    }
    //    get
    //    {
    //        return _name;
    //    }
    //}

    #region Navigation members to the [Product] model

    // 3. For Navigation from Category to Product, provide Product Collection Object reference
    //    It would NULL when the Category is created without any Products.
    public ICollection<Product>? Products { get; set; }

    #endregion
}
