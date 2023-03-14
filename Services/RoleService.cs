
using Ticketing_System.Models;

public class RoleService : IRoleService
{

    private UserContext userContext;

    public RoleService(UserContext _userContext)
    {
        userContext=_userContext;
    }


    public Role AddRole(Role role)
    {

        userContext.Add(role);
        userContext.SaveChanges();

        return role;
    }

    public List<Role> GetAllRoles()
    {
        return userContext.Set < Role > ().ToList();
    }
}