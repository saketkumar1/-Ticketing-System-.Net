

using Microsoft.EntityFrameworkCore;
using Ticketing_System.Models;

public class ProjectService : IProjectService
{

    private UserContext userContext;
    public ProjectService(UserContext _userConext)
    {
        userContext = _userConext;
    }


    public ResponseModel<List<Project>> getAllProject()
    {
        var responseModel = new ResponseModel<List<Project>>();

        try
        {
            responseModel.Data =  userContext.Projects.Include(a => a.issueList).Include(a => a.creator).ToList();
            responseModel.Messsage = "List of data";

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<Project> addProject(projectDto project)
    {
        var responseModel = new ResponseModel<Project>();

        try
        {
            User user = userContext.Find<User>(project.creatorId);

            if (user == null)
            {
                responseModel.Messsage = "user not found";
                responseModel.IsSuccess = false;
            }
            else
            {
                Project project1 = new Project()
                {
                    description = project.description,
                    creator = user

                };

                userContext.Add(project1);
                userContext.SaveChanges();

                responseModel.Data = project1;
                responseModel.Messsage = "data save";

            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;

    }


    public ResponseModel<Project> updateProject(String description,int projectId)
    {
        var responseModel = new ResponseModel<Project>();

        try
        {
            var project = userContext.Projects.FirstOrDefault(a => a.projectId == projectId);
            if (project == null)
            {
                responseModel.Messsage = "Error no project found";
                responseModel.IsSuccess = false;
            }
            else
            {
                project.description=description;
                userContext.Update<Project>(project);
                userContext.SaveChanges();

                responseModel.Messsage = "project  update";
                responseModel.Data=project;
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<Project> deleteProject(int projectId)
    {
        var responseModel = new ResponseModel<Project>();

        try
        {
            var project = userContext.Projects.FirstOrDefault(a => a.projectId == projectId);
            if (project == null)
            {
                responseModel.Messsage = "Error no project found";
                responseModel.IsSuccess = false;
            }
            else
            {
                userContext.Projects.Remove(project);
                userContext.SaveChanges();

                responseModel.Messsage = "project  deleted";
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }


    public ResponseModel<Project> getProjectDetailById(int id)
    {
        var responseModel = new ResponseModel<Project>();

        try
        {
            var project = userContext.Projects.FirstOrDefault(a => a.projectId == id);
            if (project == null)
            {
                responseModel.Messsage = "Error no project found";
                responseModel.IsSuccess = false;
            }
            else
            {

                responseModel.Data = userContext.Projects.Include(a => a.issueList).Include(a => a.creator).
        FirstOrDefault(a => a.projectId == id);
                responseModel.Messsage = "Data";
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<List<Issue>> getIssueByProjectId(int projectId)
    {
        var responseModel = new ResponseModel<List<Issue>>();

        try
        {
            var project = userContext.Projects.FirstOrDefault(a => a.projectId == projectId);
            if (project == null)
            {
                responseModel.Messsage = "Error no project found";
                responseModel.IsSuccess = false;
            }
            else
            {
                responseModel.Data = userContext.Projects.Include(a => a.issueList).
         FirstOrDefault(a => a.projectId == projectId).issueList;

                responseModel.Messsage = "Data";
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;

    }

    public ResponseModel<List<Issue>> getIssueByProjectIdAndAssigne(int projectId, string email)
    {
         var responseModel = new ResponseModel<List<Issue>>();

        try
        {
            var project = userContext.Projects.FirstOrDefault(a => a.projectId == projectId);
            var user=userContext.Users.FirstOrDefault(e=>e.email==email);
            if (project == null)
            {
                responseModel.Messsage = "Error no project found";
                responseModel.IsSuccess = false;
            }else if(user==null){
                 responseModel.Messsage = "Error no user  found with this email";
                responseModel.IsSuccess = false;
            }
            else
            {
                responseModel.Data= userContext.Issues.Include(a=>a.Assignee).
                    Where(p=>(p.Project.projectId==projectId)&&(p.Assignee.email==email)).ToList();

                responseModel.Messsage = "Data";
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<List<Issue>> getIssueByProjectIdOrAssigne(int projectId, string email)
    {
         var responseModel = new ResponseModel<List<Issue>>();

        try
        {
            var project = userContext.Projects.FirstOrDefault(a => a.projectId == projectId);
            if (project == null)
            {
                responseModel.Messsage = "Error no project found";
                responseModel.IsSuccess = false;
            }
            else
            {
        
                   responseModel.Data= userContext.Issues.Include(a=>a.Assignee).
                    Where(p=>(p.Project.projectId==projectId)||(p.Assignee.email==email)).ToList();

                responseModel.Messsage = "Data";
            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }
}