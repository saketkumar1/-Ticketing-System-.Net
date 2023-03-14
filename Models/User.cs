using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ticketing_System.Models;
public class User
{
    [Key]
    public int userId { get; set; }

    public String email { get; set; }

    public String password { get; set; }

    public String name { get; set; }

    public String designation { get; set; }

    public List<Role> rolesList { get; set; }

    [JsonIgnore]
    public List<Project> projectsList { get; set; }


    [JsonIgnore]
    [InverseProperty("Reporter")]
    public virtual ICollection<Issue> Reporter { get; set; }

    [JsonIgnore]
    [InverseProperty("Assignee")]
    public virtual ICollection<Issue> Assignee { get; set; }

}