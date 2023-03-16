using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Ticketing_System.Models;

public class UserService : IUserService
{

    private UserContext userContext;

    public UserService(UserContext _userContext)
    {
        userContext = _userContext;
    }


    // To Addding user in database
    public ResponseModel<User> SignUp(userSignUpDto user)
    {
        var responseModel = new ResponseModel<User>();

        try
        {
            // to avoide duplication 
            if (UserExists(user.email))
            {
                responseModel.Messsage = "user already exist";
                responseModel.IsSuccess = false;

            }
            else
            {
                User u = new User();

                u.email = user.email;
                u.password = user.password;
                u.name = user.name;
                u.rolesList = new List<Role>();
                u.projectsList = new List<Project>();
                u.designation = user.designation;

                userContext.Add(u);
                userContext.SaveChanges();

                responseModel.Data = u;
                responseModel.Messsage = "user Added Successfully";
            }

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }


        return responseModel;
    }

    public bool UserExists(string username)
    {
        if (userContext.Users.Any(u => u.email.ToLower() == username.ToLower()))
            return true;
        return false;
    }

    // login user 
    public ResponseModel<User> Login(userloginDto userdto)
    {

        var responseModel = new ResponseModel<User>();

        try
        {
            var user = findUserByEmail(userdto.email);
            // checking valid user or not
            if (user == null)
            {
                responseModel.Messsage = "No user Found with this Email";
                responseModel.IsSuccess = false;
            }
            // checking password
            else if (userdto.password == user.password)
            {
                responseModel.Messsage = CreateToken(user);
            }
            else
            {
                responseModel.Messsage = "wrong password";
                responseModel.IsSuccess = false;
            }

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }

        return responseModel;
    }

    public User findUserByEmail(String email)
    {
        return userContext.Users.FirstOrDefault(u => u.email.ToLower() == email.ToLower());
    }

    // creating token using jwt
    private string CreateToken(User ur)
    {

        User u = userContext.Users.Include(a => a.rolesList).
          FirstOrDefault(a => a.userId == ur.userId);


        List<Claim> claimList = new List<Claim>();

        if (ur.rolesList == null || ur.rolesList.Count == 0)
        {
            return "please add role";
        }

        // adding role to claim list
        foreach (var item in u.rolesList)
        {
            claimList.Add(new Claim("roles", item.name));
        }


        var secretKey = new SymmetricSecurityKey
                   (Encoding.UTF8.GetBytes("Thisismysecretkey"));
        var signinCredentials = new SigningCredentials
       (secretKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            "https://localhost:7154",
            "https://localhost:7154",
            claims: claimList,
            expires: DateTime.Now.AddMinutes(10),
            signingCredentials: signinCredentials
        );
        return new JwtSecurityTokenHandler().
        WriteToken(jwtSecurityToken);

    }


    // adding role to user by userid and roleid
    public ResponseModel<User> AddRole(int userId, int roleId)
    {

        var responseModel = new ResponseModel<User>();

        try
        {

            var user = userContext.Users.FirstOrDefault(u => u.userId == userId);
            var role = userContext.Roles.FirstOrDefault(u => u.roleId == roleId);

            if (user == null)
            {
                responseModel.Messsage = "user does not exist";
                responseModel.IsSuccess = false;

            }
            else if (role == null)
            {
                responseModel.Messsage = "role does not exist";
                responseModel.IsSuccess = false;
            }
            else
            {

                if (user.rolesList == null)
                {
                    user.rolesList = new List<Role>();
                }


                user.rolesList.Add(role);
                userContext.Update<User>(user);
                userContext.SaveChanges();

                responseModel.Data = userContext.Users.Include(s => s.rolesList).
                                     FirstOrDefault(a => a.userId == userId);
                responseModel.Messsage = "user Added Successfully";

            }

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }


        return responseModel;
    }

    // deleting user by user id
    public ResponseModel<User> DeleteUser(int userId)
    {

        var responseModel = new ResponseModel<User>();

        try
        {

            var user = userContext.Users.FirstOrDefault(u => u.userId == userId);

            if (user == null)
            {
                responseModel.Messsage = "user does not exist";
                responseModel.IsSuccess = false;
            }
            else
            {

                userContext.Remove(user);
                userContext.SaveChanges();

                responseModel.Messsage = "user Deleted";

            }

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }

        return responseModel;

    }


    // pending ask
    public  ResponseModel<User> updateUser(userSignUpDto user,int userId)
    {
        var responseModel = new ResponseModel<User>();

        try
        {
             var u = userContext.Users.FirstOrDefault(u => u.userId == userId);

            // to avoide duplication 
            if (UserExists(user.email)&&u!=null)
            {
                
               

                u.email = user.email;
                u.password = user.password;
                u.name = user.name;
                u.designation = user.designation;

                userContext.Update(u);
                userContext.SaveChanges();

                responseModel.Data = u;
                responseModel.Messsage = "user Added Successfully";
            }

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }


        return responseModel;
    }

    public ResponseModel<List<User>> getAllUser()
    {
        var responseModel = new ResponseModel<List<User>>();

        try
        {
            responseModel.Data = userContext.Users.Include(a => a.rolesList).Include(a => a.projectsList).ToList();
            responseModel.Messsage = "success";

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<User> getUserDetail(int userId)
    {
        var responseModel = new ResponseModel<User>();

        try
        {
            var user = userContext.Users.Include(a => a.rolesList).Include(a => a.projectsList).
                        FirstOrDefault(a => a.userId == userId);

            if (user == null)
            {
                responseModel.Messsage = "user does not exist";
                responseModel.IsSuccess = false;
            }

            responseModel.Data = user;
            responseModel.Messsage = "user detail by id";

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;

    }
}