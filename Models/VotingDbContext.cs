using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_voting_demo.Models
{
    public class VotingDbContext : DbContext
    {
        public VotingDbContext(DbContextOptions<VotingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vote> Votes { get; set; }
        public DbSet<VoteValue> VoteValues { get; set; }
        public DbSet<VoteResult> VoteResults { get; set; }
    }
}
