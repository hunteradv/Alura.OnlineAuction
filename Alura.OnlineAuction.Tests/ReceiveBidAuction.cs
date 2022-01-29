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
            var client2 = new Client("Cliente teste 2", auctionTest);

            auctionTest.StartAuction();

            for(var i = 0; i < bids.Length; i++)
            {
                var value = bids[i];
                if (i % 2 == 0)
                {
                    auctionTest.ReceiveBid(client1, value);
                }
                else
                {
                    auctionTest.ReceiveBid(client2, value);
                }
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

        [Fact]
        public void NotAllowBidsBeforeAuctionStarts()
        {
            //assert
            //leilão é criado e até o momento sem lances
            var auctionTest = new Auction("Pintura Van Gogh");
            var client1 = new Client("Cliente teste", auctionTest);

            //act
            //realizado lance antes do leilão iniciar

            auctionTest.ReceiveBid(client1, 1000);

            auctionTest.StartAuction();

            auctionTest.ReceiveBid(client1, 1000);

            var expectedValue = 1;
            var valueObtained = auctionTest.Bids.Count();

            //assert
            //Então é eseprado que o lance antes de o leilão ter iniciado é ignorado
            Assert.Equal(expectedValue, valueObtained);
        }

        [Fact]
        public void NotAllowBidsFollowedByTheSamePerson()
        {
            //arranje - cenário
            //Dado leilão com um lance do cliente 1

            var auction = new Auction("Leilão teste");
            var client1 = new Client("Cliente teste", auction);

            auction.StartAuction();

            auction.ReceiveBid(client1, 1000);

            //Act
            //Quando o mesmo cliente realiza um novo lance

            auction.ReceiveBid(client1, 1200);

            auction.FinishAuction();

            var expectedValue = 1;
            var valueObtained = auction.Bids.Count();

            //Assert
            //Então o segundo lance é ignorado
            Assert.Equal(expectedValue, valueObtained);
        }
    }
}
