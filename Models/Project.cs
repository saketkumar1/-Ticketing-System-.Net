using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Ticketing_System.Models;

public class Project
{

    [Key]
    public int projectId { get; set; }

    public String description { get; set; }

    
    public User? creator { get; set; }

    public List<Issue> issueList { get; set; }


}