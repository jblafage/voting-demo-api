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

        public DbSet<VoteValue> VoteValues { get; set; }
        public DbSet<VoteResult> VoteResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region VoteValue

            modelBuilder.Entity<VoteValue>().HasData(
                new VoteValue() { Id = 1, Name = "Cats" },
                new VoteValue() { Id = 2, Name = "Dogs" });

            #endregion
        }
    }
}
