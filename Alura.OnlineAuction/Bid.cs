using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.OnlineAuction
{
    public class Bid
    {
        public Client Client { get; set; }
        public double Value { get; set; }

        public Bid(Client client, double value)
        {
            Client = client;
            Value = value;
        }
    }
}