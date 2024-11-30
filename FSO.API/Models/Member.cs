using System.ComponentModel.DataAnnotations.Schema;

namespace FSO.API.Models;

//[Table("members", Schema = "fso")]
public class Member{

    public Guid Id { get; set; }
    public required string Name { get; set; }
    
}