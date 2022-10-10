using System.ComponentModel.DataAnnotations;
public class Category
{
    [Key]
    public Guid Guid { get; set; }
    public string Name { get; set; }
}