namespace MyCVproject.Models;

public class App
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public int PersonId { get; set; }
    public Person Person { get; set; }
}