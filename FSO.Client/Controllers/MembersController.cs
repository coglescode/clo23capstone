using Microsoft.AspNetCore.Mvc;
using FSO.Client.Models;
using FSO.Client.Services;

namespace FSO.Client.Controllers;

public class MembersController : Controller
{
    private readonly MembersApiService _membersApiService;

    public MembersController(MembersApiService membersApiService)
    {
        _membersApiService = membersApiService;
    }
    
    public async Task<IActionResult> Index()
    {
        // Get all products from the API service
        var membersFromApiService = await _membersApiService.GetMembersAsync();

        // Map the API DTO to the api model
        var members = membersFromApiService.Select(p => new MemberViewModel
        {
            Id = p.Id,
            Name = p.Name
        });

        // Mocked API data
        //var products = GetProducts();

        return View(members);
    }


    // Mocked API data. Private method to simulate API call
    private List<MemberViewModel> GetMembers()
    {
        return new List<MemberViewModel>
        {
            new MemberViewModel
            {
                Id = 1,
                Name = "Product 1",
               
            },
            new MemberViewModel
            {
                Id = 2,
                Name = "Product 2",
               
            },
            new MemberViewModel
            {
                Id = 3,
                Name = "Product 3",
                
            }
        };
    }
}