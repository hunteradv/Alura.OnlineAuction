
using Xunit;

namespace Alura.OnlineAuction.Tests
{
    public class AuctionTest
    {

        //Verifica se a mesma pessoa realiza dois lances, ainda encontra o vencedor correto.
        [Fact]
        public static void AuctionWithAtLeastOneBid()
        {
            //arranje - cenário
            //Dado leilão de pelo menos um lance
            var auctionTest = new Auction("Pintura Van Gogh");

            var client1 = new Client("Cliente 1", auctionTest);
            var client2 = new Client("Cliente 2", auctionTest);
            var client3 = new Client("Cliente 3", auctionTest);

            auctionTest.ReceiveBid(client1, 1000);
            auctionTest.ReceiveBid(client2, 1100);
            auctionTest.ReceiveBid(client3, 1200);
            auctionTest.ReceiveBid(client2, 2000);

            //Act - método sob teste
            //Quando o leilão termina e decide um vencedor
            auctionTest.FinishTrading();

            var expectedValue = 2000;

            //Assert
            //Então o valor esperado é o maior dado
            //E o Cliente vencedor é o que deu o maior lance
            Assert.Equal(client2, auctionTest.Winner.Client);
            Assert.Equal(expectedValue, auctionTest.Winner.Value);
        }

        

        ////Verifica se a mesma pessoa realiza dois lances, ainda encontra o vencedor correto.
        //[Fact]
        //public static void AuctionWithMultibleBidsOfOneClient()
        //{
        //    //arranje - cenário
        //    var auctionTest = new Auction("Pintura Van Gogh");

        //    var client1 = new Client("Cliente 1", auctionTest);
        //    var client2 = new Client("Cliente 2", auctionTest);
        //    var client3 = new Client("Cliente 3", auctionTest);

        //    auctionTest.ReceiveBid(client1, 1000);
        //    auctionTest.ReceiveBid(client2, 1100);
        //    auctionTest.ReceiveBid(client3, 1200);
        //    auctionTest.ReceiveBid(client2, 2000);

        //    //Act - método sob teste
        //    auctionTest.FinishTrading();

        //    var expectedValue = 2000;

        //    //Assert
        //    Assert.Equal(client2, auctionTest.Winner.Client);
        //    Assert.Equal(expectedValue, auctionTest.Winner.Value);
        //}

        ////Verifica se houver vários lances, ainda encontra o vencedor correto.
        //[Fact]
        //public static void AuctionWithMultipleBids()
        //{

        //    var auctionTest = new Auction("Pintura Van Gogh");

        //    var client1 = new Client("Cliente 1", auctionTest);
        //    var client2 = new Client("Cliente 2", auctionTest);
        //    var client3 = new Client("Cliente 3", auctionTest);

        //    auctionTest.ReceiveBid(client1, 1000);
        //    auctionTest.ReceiveBid(client2, 1100);
        //    auctionTest.ReceiveBid(client3, 500);

        //    //Act
        //    auctionTest.FinishTrading();

        //    var expectedValue = 1100.0;
        //    var valueObtained = auctionTest.Winner.Value;

        //    //Assert
        //    Assert.Equal(expectedValue, valueObtained);

        //}


        ////Verifica se a mesma pessoa realiza dois lances, ainda encontra o vencedor correto.
        //[Fact]
        //public static void AuctionWithOneBid()
        //{
        //    var auctionTest = new Auction("Pintura Van Gogh");

        //    var client1 = new Client("Cliente 1", auctionTest);

        //    auctionTest.ReceiveBid(client1, 1000);

        //    auctionTest.FinishTrading();

        //    var expectedValue = 1000;
        //    var valueObtained = auctionTest.Winner.Value;

        //    Assert.Equal(expectedValue, valueObtained);
        //}
    }
}
