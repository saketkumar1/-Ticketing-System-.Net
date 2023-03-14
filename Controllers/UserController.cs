using Microsoft.AspNetCore.Mvc;
using Ticketing_System.Models;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    private IUserService userService;
    private readonly ILogger logger;

    public UserController(IUserService _userService, ILoggerFactory _logger)
    {
        userService = _userService;
        logger = _logger.CreateLogger("MyCategory");

    }


    [HttpPost]
    [Route("[action]")]
    public IActionResult UserSignUp(userSignUpDto user)
    {
        logger.LogInformation("User Register Method is called...........");

        try
        {
            return Ok(Ok(userService.SignUp(user)));
        }
        catch (Exception)
        {
            return BadRequest();
        }


    }

    [HttpPost]
    [Route("[action]")]
    public IActionResult UserLogin(userloginDto user)
    {

        logger.LogInformation("User UserLogin Method is called...........");

        try
        {
            return Ok(userService.Login(user));
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }


    [HttpPost]
    [Route("[action]")]
    public IActionResult AddRole(int userId, int roleId)
    {
        logger.LogInformation("User AddRole Method is called...........");

        try
        {
            return Ok(userService.AddRole(userId, roleId));
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }


    [HttpDelete]
    [Route("[action]/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        logger.LogInformation("User DeleteUser Method is called...........");

        try
        {
            return Ok(userService.DeleteUser(userId));
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }

    [HttpGet]
    [Route("[action]/{userId}")]
    public IActionResult getUserDetail(int userId)
    {
        logger.LogInformation("User getUserDetail Method is called...........");

        try
        {
            return Ok(userService.getUserDetail(userId));
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }


    [HttpPut]
    [Route("[action]")]
    public IActionResult updateUser(userSignUpDto user, int userId)
    {
        logger.LogInformation("User updateUser Method is called...........");

        try
        {
            return Ok(userService.updateUser(user, userId));
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }



    [HttpGet]
    [Route("[action]")]
    public IActionResult getAllUser()
    {

        logger.LogInformation("User getAllUser Method is called...........");

        try
        {
            return Ok(userService.getAllUser());
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }


}