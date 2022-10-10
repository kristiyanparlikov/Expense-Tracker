using System.ComponentModel.DataAnnotations;
public class User
{
    [Key]
    public Guid Guid { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Role { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.Now;

    public virtual ICollection<Transaction> Transactions {get; set;}



}