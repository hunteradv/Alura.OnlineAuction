using System;
using Xunit;

namespace Alura.OnlineAuction.Tests
{
    public class BidCtor
    {
        [Fact]
        public static void ThrowArgumentExceptionWhenReceivedBidWithNegativeValue()
        {
            var modality = new BidMaxValue();
            //arranje
            var auction = new Auction("Auction Test", modality);

            var valorNegativo = -1;

            //assert
            Assert.Throws<ArgumentException>(
                //act
                () => new Bid(null, valorNegativo)
                );
        }
    }
}
