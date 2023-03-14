using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] 
public class ProjectController : ControllerBase
{


    private IProjectService projectService;

    private readonly ILogger logger;

    public ProjectController(IProjectService _projectService, ILoggerFactory _logger)
    {
        projectService = _projectService;
        logger = _logger.CreateLogger("MyCategory");
    }

    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles="admin,manager")]
    public IActionResult AddProject(projectDto project)
    {
        logger.LogInformation("projed add Method is called...........");

        try
        {
            return Ok(projectService.addProject(project));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager")]
    public IActionResult GetAllProject()
    {
        logger.LogInformation("projed GetAllProject Method is called...........");

        try
        {
             return Ok(projectService.getAllProject());
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }


    [HttpPut]
    [Route("[action]/{projectId}")]
    [Authorize(Roles="admin,manager")]
    public IActionResult updateProject(String description,int projectId)
    {
          logger.LogInformation("projed updateProject Method is called...........");

        try
        {
             return Ok(projectService.updateProject(description,projectId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
        
    }



    [HttpDelete]
    [Route("[action]/{projectId}")]
    [Authorize(Roles="admin,manager")]
    public IActionResult deleteProject(int projectId)
    {
          logger.LogInformation("projed deleteProject Method is called...........");

        try
        {
              return Ok(projectService.deleteProject(projectId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }


    [HttpGet]
    [Route("[action]/{projectid}")]
    [Authorize(Roles="admin,manager")]
    public IActionResult getProjectDetailById(int projectid)
    {
          logger.LogInformation("projed getProjectDetailById Method is called...........");

        try
        {
             return Ok(projectService.getProjectDetailById(projectid));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }


    [HttpGet]
    [Route("[action]/{projectId}")]
    [Authorize(Roles="admin,manager")]
    public IActionResult getIssueByProjectId(int projectId)
    {
          logger.LogInformation("projed getIssueByProjectId Method is called...........");

        try
        {
            return Ok(projectService.getIssueByProjectId(projectId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager")]
    public IActionResult getIssueByProjectIdAndAssigne(int projectId, String email)
    {
          logger.LogInformation("projed add Method is called...........");

        try
        {
              return Ok(projectService.getIssueByProjectIdAndAssigne(projectId, email));
        }
        catch (Exception)
        {
            return BadRequest();
        }
      
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager")]
    public IActionResult getIssueByProjectIdOrAssigne(int projectId, String email)
    {
          logger.LogInformation("projed getIssueByProjectIdOrAssigne Method is called...........");

        try
        {
              return Ok(projectService.getIssueByProjectIdOrAssigne(projectId, email));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }

}