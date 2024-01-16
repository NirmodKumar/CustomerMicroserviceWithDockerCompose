using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Customer
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required, Column("Customer_Id")]
    public int Id { get; set; }
    [Required, Column("Customer_FName")]
    public string FName { get; set; }
    [Required, Column("Customer_LName")]
    public string LName { get; set; }
    [Required, Column("Customer_Gender")]
    public string Gender { get; set; }
    [Column("Customer_Address")]
    public string Address { get; set; }
    [Required, Column("Customer_ContactNo")]
    public string ContactNo { get; set; }

    [Required, Column("Customer_EmailId")]
    public string EmailId { get; set; }
}