

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ticketing_System.Models;

public class Issue
{


    [Key]
    public int issueId { get; set; }

    public String title { get; set; }
    public String description { get; set; }

    public String status { get; set; }

    public String Type { get; set; }

    public DateTime createDate { get; set; }

    public DateTime updateDate { get; set; }

    [JsonIgnore]
    public Project? Project { get; set; }

    public int ReporterId { get; set; }
    
    public User Reporter { get; set; }

    public int? AssigneeId { get; set; }

    public User? Assignee { get; set; }

    public List<Label>? listLabel { get; set; }


}