
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
public class IssueController : ControllerBase
{


    private IIssueService issueService;

    private readonly ILogger logger;

    public IssueController(IIssueService _issueService, ILoggerFactory _logger)
    {
        issueService = _issueService;
        logger = _logger.CreateLogger("MyCategory");
    }



    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult AddIssue(issueDto issue)
    {
        logger.LogInformation("issue AddIssue Method is called...........");

        try
        {
            return Ok(issueService.addIssue(issue));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }


    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult GetAllIssues()
    {
        logger.LogInformation("issue GetAllIssues Method is called...........");

        try
        {
            return Ok(issueService.getAllIssue());
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }


    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult UpdateIssueSatus(int issueId)
    {
        logger.LogInformation("issue UpdateIssueSatus Method is called...........");

        try
        {
             return Ok(issueService.UpdateIssueStatus(issueId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }


    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult DownGradeIssueSatus(int issueId, int level)
    {
        logger.LogInformation("issue DownGradeIssueSatus Method is called...........");

        try
        {
             return Ok(issueService.DownGradeIssueStatus(issueId, level));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }


    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult getIssueById(int issueId)
    {
        logger.LogInformation("issue getIssueById Method is called...........");

        try
        {
            return Ok(issueService.getIssueById(issueId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }

    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult assignIssueToUser(int issueId, int userId)
    {
        logger.LogInformation("issue assignIssueToUser Method is called...........");

        try
        {
             return Ok(issueService.assignIssueToUser(issueId, userId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }

    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult deleteIssue(int issueId)
    {
        logger.LogInformation("issue deleteIssue Method is called...........");

        try
        {
             return Ok(issueService.deleteIssue(issueId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }


    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult AddLabel(Label label)
    {
        logger.LogInformation("issue AddLabel Method is called...........");

        try
        {
            return Ok(issueService.addlabel(label));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }


    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult addIssueInProject(int issueId, int projectId)
    {
        logger.LogInformation("issue addIssueInProject Method is called...........");

        try
        {
             return Ok(issueService.addIssueInProject(issueId, projectId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult getIssueInProject(int issueId, int projectId)
    {
        logger.LogInformation("issue getIssueInProject Method is called...........");

        try
        {
           return Ok(issueService.getIssueInProject(issueId, projectId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
        
    }

    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult updateIssueInProject(issueDto issuedto, int projectId, int issueId)
    {
        logger.LogInformation("issue updateIssueInProject Method is called...........");

        try
        {
            return Ok(issueService.updateIssueInProject(issuedto, projectId, issueId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }

    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult deletedIssueInProject(int issueId, int projectId)
    {
        logger.LogInformation("issue deletedIssueInProject Method is called...........");

        try
        {
            return Ok(issueService.deletedIssueInProject(issueId, projectId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult searchIssueBy(String title, String description)
    {
        logger.LogInformation("issue searchIssueBy Method is called...........");

        try
        {
           return Ok(issueService.searchIssueBy(title, description));
        }
        catch (Exception)
        {
            return BadRequest();
        }
        
    }



    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult getIssueGreaterThanCreatedDate(String currentDate)
    {
        logger.LogInformation("issue getIssueGreaterThanCreatedDate Method is called...........");

        try
        {
           return Ok(issueService.getIssueGreaterThanCreatedDate(DateTime.Parse(currentDate)));
        }
        catch (Exception)
        {
            return BadRequest();
        }
        

    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult getIssueLessThanUpdateDate(String updateDate)
    {
        logger.LogInformation("issue add getIssueLessThanUpdateDate is called...........");

        try
        {
            return Ok(issueService.getIssueLessThanUpdateDate(DateTime.Parse(updateDate)));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       

    }


    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,manager,standard")]
    public IActionResult getIssueByTypes(String type)
    {
        logger.LogInformation("issue getIssueByTypes Method is called...........");

        try
        {
             return Ok(issueService.getIssueByTypes(type));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }

}