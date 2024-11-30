using Microsoft.AspNetCore.Mvc;
using FSO.Client.Models;
using FSO.Client.Services;
using Microsoft.Identity.Client;
namespace FSO.Client.Controllers;

public class MembersController : Controller
{
    private readonly MembersApiService _membersApiService;

    public MembersController(MembersApiService membersApiService)
    {
        _membersApiService = membersApiService;
    }
       
    // Get all members from the API service
    public async Task<IActionResult> Index()
    {
        var membersFromApiService = await _membersApiService.GetMembersAsync();
    
        //if (!membersFromApiService.Any())
        if (membersFromApiService != null)
        {
            var members = membersFromApiService.Select(member => new MemberViewModel
            {
                Id = member.Id,
                Name = member.Name
            }).ToList();


            return View(members);
        }
        else
        {
            var members = new MemberViewModel();
            return View(members);
        }

        //var members = membersFromApiService.Select(member => new MemberViewModel
        //{
        //    Id = member.Id,
        //    Name = member.Name
        //}).ToList();

        //if (members == null || members.Count == 0)
        //{
        //    return NotFound("Lista vacia.");
        //}        
                
    }

    public async Task<IActionResult> DeleteMember(Guid id)
    {
        var memberId = await _membersApiService.DeleteMembersAsync(id);
        return RedirectToAction("Index", "Members");
  
    }

    public async Task<IActionResult> PostMember(MemberViewModel memberView)
    {
        var member = new MembersApiDTO
        {
            //Id = memberView.Id,
            Name = memberView.Name
        };

        var memberName = await _membersApiService.PostMembersAsync(member);
        return RedirectToAction("Index", "Members");

    }

    // Mocked API data. Private method to simulate API call
    //private List<MemberViewModel> GetMembers()
    //{
    //    return new List<MemberViewModel>
    //    {
    //        new MemberViewModel
    //        {
    //            Id = 1,
    //            Name = "Product 1",
               
    //        },
    //        new MemberViewModel
    //        {
    //            Id = 2,
    //            Name = "Product 2",
               
    //        },
    //        new MemberViewModel
    //        {
    //            Id = 3,
    //            Name = "Product 3",
                
    //        }
    //    };
    //}
}