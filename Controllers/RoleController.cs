using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ticketing_System.Models;

namespace Ticketing_System.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] 
public class RoleController : ControllerBase
{

    private IRoleService roleService;

    private readonly ILogger logger;

    public RoleController(IRoleService _roleService,ILoggerFactory _logger)
    {
        roleService = _roleService;
        logger = _logger.CreateLogger("MyCategory");
    }


    [HttpPost]
    [Route("[action]")]
     [Authorize(Roles="admin")]
    public IActionResult AddRole(Role role)
    {
        logger.LogInformation("role add Method is called...........");

        try
        {
             return Ok(roleService.AddRole(role));
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }


    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles="admin,standard")]
    public IActionResult GetAllRoles()
    {
        logger.LogInformation("role get all Method is called...........");

        try
        {
             return Ok(roleService.GetAllRoles());
        }
        catch (Exception)
        {
            return BadRequest();
        }
       
    }

}
