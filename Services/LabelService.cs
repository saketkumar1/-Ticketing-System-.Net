


using Microsoft.EntityFrameworkCore;

public class LabelService : ILabelService
{

    private UserContext userContext;

    public LabelService(UserContext _userContext)
    {
        userContext = _userContext;
    }

    public ResponseModel<Label> addLabel(Label label)
    {
        var responseModel = new ResponseModel<Label>();

        try
        {

            userContext.Add(label);
            userContext.SaveChanges();

            responseModel.Data = label;
            responseModel.Messsage = "Data";

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<Issue> addLabelToIssue(int issueId, int labelId)
    {
        var responseModel = new ResponseModel<Issue>();

        try
        {
            var issue = userContext.Issues.FirstOrDefault(a => a.issueId == issueId);
            var label = userContext.Labels.FirstOrDefault(a => a.labelId == labelId);

            if (issue == null)
            {
                responseModel.Messsage = "Error no issue found";
                responseModel.IsSuccess = false;
            }
            else if (label == null)
            {
                responseModel.Messsage = "Error no label found";
                responseModel.IsSuccess = false;
            }
            else
            {
                if (issue.listLabel == null)
                {
                    issue.listLabel = new List<Label>();
                }

                issue.listLabel.Add(label);
                userContext.Update<Issue>(issue);
                userContext.SaveChanges();

                responseModel.Data = issue;
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

    public ResponseModel<Label> deleteLabel(int labelId)
    {
        var responseModel = new ResponseModel<Label>();

        try
        {

            var label = userContext.Find<Label>(labelId);

            if (label == null)
            {
                responseModel.Messsage = "Error no label found";
                responseModel.IsSuccess = false;
            }
            else
            {
                userContext.Labels.Remove(label);
                userContext.SaveChanges();

                responseModel.Messsage = "label deleted";
            }

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<Issue> deleteLabelToIssue(int issueId, int labelId)
    {
        var responseModel = new ResponseModel<Issue>();

        try
        {

            var issue = userContext.Issues.Include(a => a.listLabel).FirstOrDefault(c => c.issueId == issueId);
            var label = userContext.Find<Label>(labelId);

            if (issue == null)
            {
                responseModel.Messsage = "Error no issue found";
                responseModel.IsSuccess = false;
            }
            else if (label == null)
            {
                responseModel.Messsage = "Error no label found";
                responseModel.IsSuccess = false;
            }
            else
            {

                if (issue.listLabel == null || issue.listLabel.Count == 0)
                {
                    responseModel.Messsage = "label not found in issue ";
                        responseModel.IsSuccess = false;
                }
                else
                {

                    bool help = false;
                    for (int i = 0; i < issue.listLabel.Count; i++)
                    {
                        var temp = issue.listLabel[i];
                        if (temp.labelId == labelId)
                        {
                            issue.listLabel.RemoveAt(i);
                            userContext.Update<Issue>(issue);
                            userContext.SaveChanges();
                            help = true;
                            break;
                        }
                    }

                    if (help)
                    {

                        responseModel.Data = issue;
                        responseModel.Messsage = "label deleted ";
                    }
                    else
                    {
                        responseModel.Messsage = "label not found in issue ";
                        responseModel.IsSuccess = false;
                    }


                }

            }
        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }

    public ResponseModel<List<Label>> getAllLabels()
    {
        var responseModel = new ResponseModel<List<Label>>();

        try
        {
            responseModel.Data = userContext.Set<Label>().ToList();
            responseModel.Messsage = "Data";

        }
        catch (Exception ex)
        {
            responseModel.Messsage = ex.Message;
            responseModel.IsSuccess = false;
        }
        return responseModel;
    }
}