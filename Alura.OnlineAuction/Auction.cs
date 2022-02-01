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
        public Client LastClient { get; set; }
        public double DestinyValue { get; set; }

        public Auction(string item, double destinyValue = 0)
        {
            if(item is null)
            {
                throw new Exception("Item não pode ser nulo");
            }

            Item = item;
            bids = new List<Bid>();
            Status = EnumStatusAuction.WaitingToOpen;
            DestinyValue = destinyValue;
        }

        private bool NewBidIsAccepted(Client client, double value)
        {
            return (Status == EnumStatusAuction.Open) && (client != LastClient);
        }

        public void ReceiveBid(Client client, double value)
        {
            if (NewBidIsAccepted(client, value))
            {
                bids.Add(new Bid(client, value));
                LastClient = client;   
            }
        }

        public void StartAuction()
        {
            Status = EnumStatusAuction.Open;
        }

        public void FinishAuction()
        {
            if(Status != EnumStatusAuction.Open)
            {
                throw new InvalidOperationException("Não é possível encerrar um leilão sem te-lo iniciado");
            }

            //modalidade oferta superior mais próxima
            if(DestinyValue > 0)
            {
                Winner = Bids.DefaultIfEmpty(new Bid(null, 0)).Where(x => x.Value > DestinyValue).OrderBy(x => x.Value).LastOrDefault();
            }
            //modalidade maior valor
            else
            {
                Winner = Bids.DefaultIfEmpty(new Bid(null, 0)).OrderBy(x => x.Value).LastOrDefault();
            }

            Status = EnumStatusAuction.Closed;
        }
    }

}
