using System;
using Xunit;

namespace Alura.OnlineAuction.Tests
{
    public class FinishAuction
    {
        //Verifica se a mesma pessoa realiza dois lances, ainda encontra o vencedor correto.
        [Theory]
        [InlineData(1950, 2000, new double[] { 1000, 1100, 1200, 2000 })]
        [InlineData(1950, 2000, new double[] { 1000, 1100, 2000, 1200 })]
        [InlineData(750, 800, new double[] { 800 })]

        public static void ReturnMaxValueWhenHaveAtLeastOneBid(double destinyValue, double expectedValue, double[] bids)
        {
            //arranje - cenário
            var modality = new NearestToDestinyValue(destinyValue);
            var auctionTest = new Auction("Pintura Van Gogh", modality);

            var client1 = new Client("Cliente teste", auctionTest);
            var client2 = new Client("Cliente teste 2", auctionTest);

            auctionTest.StartAuction();

            for (var i = 0; i < bids.Length; i++)
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

            //Act - método sob teste
            auctionTest.FinishAuction();

            //Assert
            Assert.Equal(expectedValue, auctionTest.Winner.Value);
        }

        [Fact]
        public static void ReturnZeroWhenNoHaveBids()
        {
            //arranje - cenário
            //Dado leilão com nenhum lance
            var modality = new BidMaxValue();

            var auctionTest = new Auction("Pintura Van Gogh", modality);

            auctionTest.StartAuction();

            //Act - método sob teste
            //Quando o leilão termina e tenta decidir um vencedor
            auctionTest.FinishAuction();

            var expectedValue = 0;
            var valueObtained = auctionTest.Winner.Value;
            //Client expectedClient = null;

            //Assert
            //Então o valor esperado é zero
            //E não há vencedor (null)
            Assert.Equal(expectedValue, valueObtained);
        }

        [Fact]
        public static void ThrowInvalidOperationExceptionWhenFinishAuctionWithoutItStarted()
        {
            //arranje
            //dado leilão sem iniciar
            var modality = new BidMaxValue();
            var auction = new Auction("Auction Test", modality);

            //assert
            Assert.Throws<InvalidOperationException>(
                () => auction.FinishAuction()
            );
        }

        [Theory]
        [InlineData(1000, 1100, new double[]{100, 600, 970, 1100})]
        public static void ReturnValueCloserToDestinyValue(double destinyValue, double expectedValue, double[]bids)
        {
            var modality = new NearestToDestinyValue(destinyValue);

            var auction = new Auction("Leilão teste", modality);

            var client1 = new Client("Cliente teste", auction);
            var client2 = new Client("Cliente teste 2", auction);

            auction.StartAuction();

            for(int i = 0; i < bids.Length; i++)
            {
                if(i%2 == 0)
                {
                    auction.ReceiveBid(client1, bids[i]);
                }
                else
                {
                    auction.ReceiveBid(client2, bids[i]);
                }
            }

            auction.FinishAuction();

            var valueObtained = auction.Winner.Value;

            Assert.Equal(expectedValue, valueObtained);
        }
    }
}
