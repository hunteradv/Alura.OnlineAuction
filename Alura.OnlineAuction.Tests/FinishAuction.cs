using Xunit;

namespace Alura.OnlineAuction.Tests
{
    public class FinishAuction
    {
        //Verifica se a mesma pessoa realiza dois lances, ainda encontra o vencedor correto.
        [Theory]
        [InlineData(2000 ,new double[] {1000, 1100, 1200, 2000})]
        [InlineData(2000 ,new double[] {1000, 1100, 2000, 1200})]
        [InlineData(800 ,new double[] {800})]

        public static void ReturnMaxValueWhenHaveAtLeastOneBid(double expectedValue, double[] oferts)
        {
            //arranje - cenário
            var auctionTest = new Auction("Pintura Van Gogh");

            var client1 = new Client("Cliente teste", auctionTest);

            foreach(var ofert in oferts)
            {
                auctionTest.ReceiveBid(client1, ofert);
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
            //Dado leilão com nenhuma lance
            var auctionTest = new Auction("Pintura Van Gogh");

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
    }
}
