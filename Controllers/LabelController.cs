
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] 
public class LabelController : ControllerBase
{

    private ILabelService labelService;

    private readonly ILogger logger;

    public LabelController(ILabelService _labelService, ILoggerFactory _logger)
    {
        labelService = _labelService;
        logger = _logger.CreateLogger("MyCategory");
    }




    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles="admin")]
    public IActionResult addLabel(Label label)
    {
        logger.LogInformation("issue add Method is called...........");

        try
        {
            return Ok(labelService.addLabel(label));
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }

    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles="admin")]
    public IActionResult deleteLabel(int labelId)
    {
        logger.LogInformation("issue deleteLabel Method is called...........");

        try
        {
            return Ok(labelService.deleteLabel(labelId));
        }
        catch (Exception)
        {
            return BadRequest();
        }


    }

    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles="admin")]
    public IActionResult addLabelToIssue(int issueId, int labelId)
    {
        logger.LogInformation("issue addLabelToIssue Method is called...........");

        try
        {
            return Ok(labelService.addLabelToIssue(issueId, labelId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }


    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin")]
    public IActionResult getAllLabels()
    {
        logger.LogInformation("label getAllLabels Method is called...........");

        try
        {
            return Ok(labelService.getAllLabels());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    [Route("[action]")]
    [Authorize(Roles="admin")]
    public IActionResult deleteLabelToIssue(int issueId, int labelId)
    {
        logger.LogInformation("issue deleteLabelToIssue Method is called...........");

        try
        {
            return Ok(labelService.deleteLabelToIssue(issueId, labelId));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}