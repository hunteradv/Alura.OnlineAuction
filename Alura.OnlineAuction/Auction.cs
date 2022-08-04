using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.OnlineAuction
{
    public class Auction
    {
        public IList<Bid> _bids;
        public IAssessmentModality _avaluator;
        public Client _lastClient;

        public IEnumerable<Bid> Bids => _bids;
        public string Item { get; }
        public Bid Winner { get; private set; }
        public EnumStatusAuction Status { get; private set; }

        public Auction(string item, IAssessmentModality avaluator)
        {
            if(item == null)
            {
                throw new Exception("Item não pode ser nulo");
            }

            Item = item;
            _bids = new List<Bid>();
            Status = EnumStatusAuction.WaitingToOpen;
            _avaluator = avaluator;
        }

        private bool NewBidIsAccepted(Client client, double value)
        {
            return (Status == EnumStatusAuction.Open) && (client != _lastClient);
        }

        public void ReceiveBid(Client client, double value)
        {
            if (NewBidIsAccepted(client, value))
            {
                _bids.Add(new Bid(client, value));
                _lastClient = client;   
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

            Winner = _avaluator.Evaluates(this);

            Status = EnumStatusAuction.Closed;
        }
    }

}
