using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Transaction
{
    [Key]
    public Guid Guid { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    [Required]
    public TransactionType Type { get; set; }
    [Required]
    [DisplayName("Category")]
    public string CategoryId { get; set; }
    public string Description { get; set; }

    
}


public enum TransactionType
{
    Income=0,
    Expense=1
}
