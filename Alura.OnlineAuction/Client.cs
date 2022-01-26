using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.OnlineAuction
{
    public class Client
    {
        public string Name { get; set; }
        public Auction Auction { get; set; }

        public Client(string name, Auction auction)
        {
            Name = name;
            Auction = auction;
        }
    }
}
