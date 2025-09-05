using System.ComponentModel;

namespace Demo_DemoDbWebApi.Models;


[Table(name:"Products", Schema = "dbo")]
public class Product
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ProductId { get; set; } = Guid.NewGuid();


    [Display(Name = "Product Name")]
    [Required(ErrorMessage = "{0} cannot be empty.")]
    //[MaxLength(100, ErrorMessage = "{0} can contain a maximum of {1} characters.")]
    //[MinLength(2, ErrorMessage = "{0} should have a minimum of {1} characters.")]
    [StringLength(maximumLength:100, MinimumLength = 2,
        ErrorMessage = "{0} should contain a minimum of {2} and a maximum of {1} characters.")]
    [Column( TypeName = "varchar(100)")]
    public string Name { get; set; } = string.Empty;                    


    public string? Description { get; set; }                                // NVARCHAR(MAX)

    [DefaultValue("getdate()")]
    public DateTimeOffset AddedOn { get; set; } = DateTimeOffset.Now;       // DateTime.UtcNow


    [DefaultValue(0)]                                                       // SQL Constraint DEFAULT (0) on column
    public int Quantity { get; set; } = 0;

    public bool IsAvailable { get; set; }



    #region Navigation members to the [Category] model


    // 1. Define the column mapped to the Primary Key of the Master Table
    [Required]
    public int CategoryId { get; set; }

    // 2. For Navigation from Product to Category, provide Category Object reference
    //    It would NULL when the Product is instantiated, but not Initialized.
    [ForeignKey(nameof(Product.CategoryId))]
    public Category? Category { get; set; }

    #endregion
}
