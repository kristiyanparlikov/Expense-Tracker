using System.ComponentModel.DataAnnotations;
public class Transaction
{
    [Key]
    public Guid Guid { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }
    public TransactionType type { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
}


public enum TransactionType
{
    Income,
    Expense
}
