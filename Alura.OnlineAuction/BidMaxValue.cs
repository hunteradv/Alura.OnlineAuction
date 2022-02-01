using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.OnlineAuction
{
    public class BidMaxValue : IAssessmentModality
    {
        public Bid Evaluates(Auction auction)
        {
            return auction.Bids.DefaultIfEmpty(new Bid(null, 0)).OrderBy(x => x.Value).LastOrDefault();
        }
    }
}
