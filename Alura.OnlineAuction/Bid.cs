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
            if(client is null)
            {
                throw new Exception("Cliente não pode ser nulo");
            }

            if(value <= 0)
            {
                throw new Exception("Valor não pode ser menor ou igual a zero");
            }

            Client = client;
            Value = value;
        }
    }
}
