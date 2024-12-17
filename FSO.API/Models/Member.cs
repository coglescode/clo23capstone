using System.ComponentModel.DataAnnotations.Schema;

namespace FSO.API.Models;

//[Table("members", Schema = "fso")]
public class Member{

    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    
}