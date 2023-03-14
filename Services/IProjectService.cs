

public interface IProjectService
{


    ResponseModel<List<Project>> getAllProject();

    ResponseModel<Project> getProjectDetailById(int id);

    ResponseModel<Project> addProject(projectDto project);

    ResponseModel<Project> updateProject(String description,int projectId);

    ResponseModel<Project> deleteProject(int projectId);
   
    ResponseModel<List<Issue>> getIssueByProjectId(int projectId);


   ResponseModel<List<Issue>> getIssueByProjectIdAndAssigne(int projectId,String email);

   ResponseModel<List<Issue>> getIssueByProjectIdOrAssigne(int projectId,String email);


}
