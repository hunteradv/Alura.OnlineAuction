using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.OnlineAuction
{
    public class NearestToDestinyValue : IAssessmentModality
    {
        public double DestinyValue { get; private set; }

        public NearestToDestinyValue(double destinyValue)
        {
            DestinyValue = destinyValue;
        }

        public Bid Evaluates(Auction auction)
        {
            return auction.Bids.DefaultIfEmpty(new Bid(null, 0)).Where(x => x.Value > DestinyValue).OrderBy(x => x.Value).LastOrDefault();
        }
    }
}
