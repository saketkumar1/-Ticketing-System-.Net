using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ticketing_System.Models;
public class Role
    {
        [Key]
        public int roleId { get; set; }

        public String name { get; set; }

        [JsonIgnore]
        public List<User>? usersList { get; set; }
  
    }