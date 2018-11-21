using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_voting_demo.Models
{
    public class Vote
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Visible { get; set; }

        public List<VoteValue> VoteValues { get; set; }
    }
}
