using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.OnlineAuction
{
    public class Auction
    {
        public IList<Bid> bids;
        public IEnumerable<Bid> Bids => bids;
        public string Item { get; }

        public Auction(string item)
        {
            Item = item;
            bids = new List<Bid>();
        }


        public void ReceiveBid(Client client, double value)
        {
            bids.Add(new Bid(client, value));
        }

        public void StartTrading()
        {

        }

        public void FinishTrading()
        {

        }
    }

}
