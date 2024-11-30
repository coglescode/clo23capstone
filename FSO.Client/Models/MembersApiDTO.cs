namespace FSO.Client.Models;

using System.Text.Json.Serialization;

/* Swagger Schema "Product"
{
    id	integer($int32)
    name	string
    nullable: true
    description	string
    nullable: true
    price	number($double)
}

Make sure the property decorators match the schema
*/

public class MembersApiDTO
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }


}