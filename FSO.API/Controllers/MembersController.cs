using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FSO.API.Models;


namespace FSO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ClientDbContext? _context;

        
        public MembersController(ClientDbContext context)
        {
            _context = context; 
        }


        // GET: api/Members
        [HttpGet]
        //public async Task<List<Member>> GetMembers()
        public async Task<ActionResult<List<Member>>> GetMembers()
        
        {
            var members = await _context.Members.ToListAsync();
                       
            return members.Count == 0 ? new List<Member>() : members;
        }


        // GET: api/Members/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Member>> GetMember(string id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return member;
        }
        //public IActionResult GetMembers(MembersDTO membersDTO)
        //{
        //    var member = new Member
        //    {
        //       Name = membersDTO.Name,
        //       Lastname = membersDTO.Lastname
        //    };

        //    _context.Members.Add(member);
        //    _context.SaveChanges();

        //    return Ok(member);
        //}
        //public async Task<ActionResult<Member>> GetMember(string name)
        //{
        //    var member = await _context.Members.FirstOrDefaultAsync(member => member.Name == name);
        //    if (member == null)
        //    {
        //        return NotFound();
        //    }
        //    return member;
        //}

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutMember(string? id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }
            var memberIs = new Member
            {
                //Id  = member.Id,
                Name = member.Name,
                Lastname = member.Lastname
            };

            _context.Entry(memberIs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(member.Id))
                { 
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(Member member)
        {
            _context.Members.Add(member);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MemberExists(member.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMember(string id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
            //return RedirectToAction("GetMembers");
        }

        private bool MemberExists(string id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }

    // The section below should not deleted for your own good
  
    // Original constructor to use
    //
    //public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
    //{
    //    var members = await _context.Members.ToListAsync();
    //    if (members == null || members.Count == 0)
    //    {
    //        return NotFound("La lista est� vac�a.");
    //    }
    //    return members;
    //}


    // Contructor that works showing an empty list. You get this from DanStj on Discord
    //
    //[HttpGet]
    //public async Task<List<Member>> GetMembers()
    //{
    //    var members = await _context.Members.ToListAsync();
    //    return members.Count == 0 ? new List<Member>() : members;
    //}

}
