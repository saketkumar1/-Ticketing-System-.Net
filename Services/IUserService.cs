using Ticketing_System.Models;

public interface IUserService{

    ResponseModel<User> SignUp(userSignUpDto user);

    ResponseModel<User> Login(userloginDto user);

    ResponseModel<User> DeleteUser(int userId);

    ResponseModel<User> getUserDetail(int userId);

    public  ResponseModel<User> updateUser(userSignUpDto user,int userId);

    ResponseModel<User> AddRole(int userId,int roleId);

    ResponseModel<List<User>> getAllUser();


}
