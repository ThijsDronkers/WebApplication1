using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private static List<Project> projects = new List<Project>()
        {
            new Project
            {
                Id = 1,
                Titel = "Project 1",
                Beschrijving = "Beschrijving van project 1",
                Categorie = "Categorie 1",
                GitHubUrl = "github.com/project1",
                Datum = new DateTime(2026, 10, 25)
            },
            new Project
            {
                Id = 2,
                Titel = "Project 2",
                Beschrijving = "Beschrijving van project 2",
                Categorie = "Categorie 2",
                GitHubUrl = "github.com/project2",
                Datum = new DateTime(2026, 10, 26)
            },
            new Project
            {
                Id = 3,
                Titel = "Project 3",
                Beschrijving = "Beschrijving van project 3",
                Categorie = "Categorie 3",
                GitHubUrl = "github.com/project3",
                Datum = new DateTime(2026, 10, 27)
            },
            new Project
            {
                Id = 4,
                Titel = "Project 4",
                Beschrijving = "Beschrijving van project 4",
                Categorie = "Categorie 4",
                GitHubUrl = "github.com/project4",
                Datum = new DateTime(2026, 10, 28)
            }
        };

        [HttpGet]
        public ActionResult<List<Project>> GetProjects()
        {
            return Ok(projects);
        }
    }    
}
  
