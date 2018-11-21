using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_voting_demo.Models
{
    public class VoteValue
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long VoteId { get; set; }

        public Vote Vote { get; set; }

        public List<VoteResult> VoteResults { get; set; }
    }
}
