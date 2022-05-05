using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyCVproject.Context;

using MyCVproject.Models;

namespace MyCVproject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    MyDbContext DbContext;
    
    public HomeController(MyDbContext _dbContext, ILogger<HomeController> logger)
    {
        _logger = logger;
        DbContext = _dbContext;
    }
    
    
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult MyForm()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult MyForm(FormViewModel model)
    {
        var person = new Person();
        person.Id = model.Person.Id;
        person.FirstName = model.Person.FirstName;
        person.LastName = model.Person.LastName;
        person.Email = model.Person.Email;
        person.Address = model.Person.Address;
        person.City = model.Person.City;
        person.Country = model.Person.Country;
        
        DbContext.Persons.Add(person);
        DbContext.SaveChanges();
        
        
        List<Project> projects = new List<Project>();
        foreach (var project in model.Projects)
        {
            var proj = new Project();
            proj.PersonId = person.Id;
            proj.Name = project.Name;
            projects.Add(proj);
        }
        
        DbContext.Projects.AddRange(projects);
    
    
        List<Language> languages = new List<Language>();
        foreach (var language in model.Languages)
        {
            var lang = new Language();
            lang.PersonId = person.Id;
            lang.Name = language.Name;
            languages.Add(lang);
        }
        
        DbContext.Languages.AddRange(languages);
    
    
        List<Course> courses = new List<Course>(); 
        foreach (var course in model.Courses)
        {
            var cour = new Course();
            cour.PersonId = person.Id;
            cour.Name = course.Name;
            courses.Add(cour);
        }
        DbContext.Courses.AddRange(courses);
    
    
    
        List<Hobby> hobbies = new List<Hobby>();
        foreach (var hobby in model.Hobbies)
        {
            var hob = new Hobby();
            hob.PersonId = person.Id;
            hob.Name = hobby.Name;
            hobbies.Add(hob);
        }
        DbContext.Hobbies.AddRange(hobbies);
        
        
        List<App> apps = new List<App>();
        foreach (var app in model.Apps)
        {
            var app1 = new App();
            app1.PersonId = person.Id;
            app1.Name = app.Name;
            apps.Add(app1);
        }
        DbContext.Apps.AddRange(apps);
        
        List<Site> sites = new List<Site>();
        foreach (var site in model.Sites)
        {
            var sit = new Site();
            sit.PersonId = person.Id;
            sit.Address = site.Address;
            sites.Add(sit);
        }
        DbContext.Sites.AddRange(sites);
        
        DbContext.SaveChanges();
        ViewBag.result = "Record Inserted Successfully!";
        return View(); 
    }
    

    public IActionResult Statistics()
    {
        // .Where(p=>p.Country=="UK")
        var person = DbContext.Persons.ToList();
        var project = DbContext.Projects.ToList();
        var language = DbContext.Languages.ToList();
        var course = DbContext.Courses.ToList();
        var hobby = DbContext.Hobbies.ToList();
        var app = DbContext.Apps.ToList();
        var site = DbContext.Sites.ToList();
        

        return View(person);    
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}