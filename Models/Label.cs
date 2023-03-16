


using System.Text.Json.Serialization;

public class Label{

    public int labelId { get; set; }

    public String name { get; set; }

    [JsonIgnore]
    public List<Issue>?  issue { get; set; }

}