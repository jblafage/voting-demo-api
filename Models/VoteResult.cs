using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_voting_demo.Models
{
    public class VoteResult
    {
        public long Id { get; set; }

        public DateTime VoteDate { get; set; }

        public long VoteValueId { get; set; }

    }
}
