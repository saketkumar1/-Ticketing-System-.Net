

public interface IIssueService
{


    ResponseModel<Issue> addIssue(issueDto issue);

    ResponseModel<List<Issue>> getAllIssue();

    ResponseModel<Issue> UpdateIssueStatus(int issueId);

    ResponseModel<Issue> DownGradeIssueStatus(int issueId, int level);

    ResponseModel<Issue> getIssueById(int issueId);

    ResponseModel<Issue> assignIssueToUser(int issueId, int userId);

    ResponseModel<Issue> deleteIssue(int issueId);

    ResponseModel<Label>? addlabel(Label label);


    ResponseModel<Project> addIssueInProject(int issueId, int projectId);

    ResponseModel<Issue> getIssueInProject(int issueId, int projectId);

    ResponseModel<Issue> updateIssueInProject(issueDto issuedto,int projectId,int issueId);

    ResponseModel<Issue> deletedIssueInProject(int issueId, int projectId);

    ResponseModel<List<Issue>> searchIssueBy(String title, String description);

    ResponseModel<List<Issue>> getIssueGreaterThanCreatedDate(DateTime dc); 

    ResponseModel<List<Issue>> getIssueLessThanUpdateDate(DateTime dc); 


     ResponseModel<List<Issue>> getIssueByTypes(String type); 


}