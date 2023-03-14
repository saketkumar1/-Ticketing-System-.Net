


public interface ILabelService
{


    ResponseModel<Label> addLabel(Label label);

    ResponseModel<Label> deleteLabel(int labelId);

    ResponseModel<List<Label>> getAllLabels();

    ResponseModel<Issue> addLabelToIssue(int issueId, int labelId);

    ResponseModel<Issue> deleteLabelToIssue(int issueId, int labelId);

}