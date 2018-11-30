using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_voting_demo.Models;

namespace api_voting_demo.Controllers
{
    [Route("api/votevalues")]
    [ApiController]
    public class VoteValuesController : ControllerBase
    {
        private readonly VotingDbContext _context;

        public VoteValuesController(VotingDbContext context)
        {
            _context = context;
        }

        // GET: api/VoteValues
        [HttpGet]
        public IEnumerable<VoteValue> GetVoteValues()
        {
            return _context.VoteValues.Include(value => value.VoteResults).OrderBy(v => v.Order);
        }

        // GET: api/VoteValues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoteValue([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var voteValue = await _context.VoteValues.FindAsync(id);

            if (voteValue == null)
            {
                return NotFound();
            }

            return Ok(voteValue);
        }

        // PUT: api/VoteValues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoteValue([FromRoute] long id, [FromBody] VoteValue voteValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voteValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(voteValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteValueExists(id))
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

        // POST: api/VoteValues
        [HttpPost]
        public async Task<IActionResult> PostVoteValue([FromBody] VoteValue voteValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VoteValues.Add(voteValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoteValue", new { id = voteValue.Id }, voteValue);
        }

        // DELETE: api/VoteValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoteValue([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var voteValue = await _context.VoteValues.FindAsync(id);
            if (voteValue == null)
            {
                return NotFound();
            }

            _context.VoteValues.Remove(voteValue);
            await _context.SaveChangesAsync();

            return Ok(voteValue);
        }

        private bool VoteValueExists(long id)
        {
            return _context.VoteValues.Any(e => e.Id == id);
        }
    }
}