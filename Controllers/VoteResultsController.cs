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
    [Route("api/voteresults")]
    [ApiController]
    public class VoteResultsController : ControllerBase
    {
        private readonly VotingDbContext _context;

        public VoteResultsController(VotingDbContext context)
        {
            _context = context;
        }

        // GET: api/VoteResults
        [HttpGet]
        public IEnumerable<VoteResult> GetVoteResults()
        {
            return _context.VoteResults;
        }

        // GET: api/VoteResults/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoteResult([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var voteResult = await _context.VoteResults.FindAsync(id);

            if (voteResult == null)
            {
                return NotFound();
            }

            return Ok(voteResult);
        }

        // PUT: api/VoteResults/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoteResult([FromRoute] long id, [FromBody] VoteResult voteResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voteResult.Id)
            {
                return BadRequest();
            }

            _context.Entry(voteResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteResultExists(id))
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

        // POST: api/VoteResults
        [HttpPost]
        public async Task<IActionResult> PostVoteResult([FromBody] VoteResult voteResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.VoteResults.Add(voteResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoteResult", new { id = voteResult.Id }, voteResult);
        }

        // DELETE: api/VoteResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoteResult([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var voteResult = await _context.VoteResults.FindAsync(id);
            if (voteResult == null)
            {
                return NotFound();
            }

            _context.VoteResults.Remove(voteResult);
            await _context.SaveChangesAsync();

            return Ok(voteResult);
        }

        // DELETE: api/VoteResults
        [HttpDelete]
        public async Task<IActionResult> ResetVoteResults()
        {
            var allVoteResults = _context.VoteResults;
            _context.VoteResults.RemoveRange(allVoteResults);
            await _context.SaveChangesAsync();
            return Ok("All entries removed");
        }

        private bool VoteResultExists(long id)
        {
            return _context.VoteResults.Any(e => e.Id == id);
        }
    }
}