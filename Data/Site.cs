namespace MyCVproject.Models;

public class Site
{
    public int Id { get; set; }
    public string? Address { get; set; }
    
    public int PersonId { get; set; }
    public Person Person { get; set; }
}