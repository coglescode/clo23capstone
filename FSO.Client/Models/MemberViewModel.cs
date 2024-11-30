namespace FSO.Client.Models;

/* Swagger Schema "Product"
{
    id  integer($int32)
    name    string
    nullable: true
    description string
    nullable: true
    price   number($double)
}
*/

public class MemberViewModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; } = string.Empty; 

    //public List<MemberViewModel?> MemberViewList { get; set; } = [];

}

