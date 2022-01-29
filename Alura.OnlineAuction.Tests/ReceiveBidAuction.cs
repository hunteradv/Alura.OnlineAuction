using System.Linq;
using Xunit;

namespace Alura.OnlineAuction.Tests
{
    public class ReceiveBidAuction
    {
        [Theory]
        [InlineData(2, new double[] { 100, 400 })]
        public void NotAllowNewBidsWhenTheAuctionEnds(double quantityExpected, double[]bids)
        {
            //arranje - cenário
            //Dado leilão com nenhuma lance
            var auctionTest = new Auction("Pintura Van Gogh");

            var client1 = new Client("Cliente teste", auctionTest);

            foreach(var value in bids)
            {
                auctionTest.ReceiveBid(client1, value);
            }          

            auctionTest.FinishAuction();

            //Act - método sob teste
            //Quando o leilão termina e tenta decidir um vencedor

            auctionTest.ReceiveBid(client1, 500);

            var quantityObtained = auctionTest.Bids.Count();

            //Assert
            //Então o valor esperado é zero
            //E não há vencedor (null)
            Assert.Equal(quantityExpected, quantityObtained);
        }
    }
}
