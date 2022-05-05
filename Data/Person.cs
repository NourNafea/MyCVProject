namespace MyCVproject.Models;

public class Person
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Country { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    
    public List<Course> Courses { get; set; }
    public List<Hobby> Hobbies { get; set; }
    public List<Language> Languages { get; set; }
    public List<App> Apps { get; set; }
    public List<Site> Sites { get; set; }
    public List<Project> Projects { get; set; }

}