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
        public Bid Winner { get; set; }
        public EnumStatusAuction Status { get; private set; }

        public Auction(string item)
        {
            if(item is null)
            {
                throw new Exception("Item não pode ser nulo");
            }

            Item = item;
            bids = new List<Bid>();
        }


        public void ReceiveBid(Client client, double value)
        {
            if (Status == EnumStatusAuction.Open)
            {
                bids.Add(new Bid(client, value));
            }
        }

        public void StartAuction()
        {

        }

        public void FinishAuction()
        {
            Winner = Bids.DefaultIfEmpty(new Bid(null, 0)).OrderBy(x => x.Value).LastOrDefault();
            Status = EnumStatusAuction.Closed;
        }
    }

}
