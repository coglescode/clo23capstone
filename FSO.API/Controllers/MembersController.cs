using Microsoft.AspNetCore.Mvc;

using FSO.API.Models;

namespace FSO.API.Controllers;

/*
 The ProductsController class follows the convention of ASP.NET Core for naming controllers and actions:
 The controller class name ends with "Controller" -> "ProductsController".
 The HTTP method for each action is specified using the [HttpGet], [HttpPost], [HttpPut], and [HttpDelete] attributes.
 The name of the action methods (Get, Post, Put, Delete) is not significant. 
 Routing is determined by [HttpGet], [HttpPost], [HttpPut], and [HttpDelete], not by the method name.
 */

[ApiController] // used to mark this class as a controller that uses the API behavior conventions
[Route("api/[controller]")] // all actions in this controller will start with "/api/products"
public class MembersController : ControllerBase
{
    // This is a simple in-memory data store.
    private static List<Member> members = new List<Member>
    {
        new Member { Id = 1, Name = "Karin" },
        new Member { Id = 2, Name = "Mayla"},
        new Member { Id = 3, Name = "Liliana" },
        new Member { Id = 4, Name = "Leonard"},
        // ... add more products here
    };

    // Expected URL: GET /api/products
    [HttpGet]
    public IEnumerable<Member> Get()
    {
        return members;
    }

    // Expected URL: GET /api/products/{id}
    [HttpGet("{id}")]
    public Member? Get(int id)
    {
        return members.FirstOrDefault(p => p.Id == id);
    }

    // Expected URL: POST /api/products
    [HttpPost]
    public void Post([FromBody] Member member)
    {
        members.Add(member);
    }

    // Expected URL: PUT /api/products/{id}
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Member member)
    {
        var existingMember = members.FirstOrDefault(p => p.Id == id);
        if (existingMember != null)
        {
            existingMember.Name = member.Name;
            
        }
    }

    // Expected URL: DELETE /api/products/{id}
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var member = members.FirstOrDefault(p => p.Id == id);
        if (member != null)
        {
            members.Remove(member);
        }
    }
}