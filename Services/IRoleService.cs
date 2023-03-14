using Ticketing_System.Models;

public interface IRoleService{

    Role AddRole(Role role);

    List<Role> GetAllRoles();

}
