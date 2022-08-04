// See https://aka.ms/new-console-template for more information
using Alura.OnlineAuction;

static void VerifyAuction(double expected, double obtained)
{
    if(expected != obtained)
    {
        Console.WriteLine($"TESTE FALHOU! Esperado: {expected}, Obtido: {obtained}");
    }
    else
    {
        Console.WriteLine("TESTE OK");
    }
}

static void AuctionWithMultipleBids()
{
    //arranje
    var modality = new BidMaxValue();
    var auctionTest = new Auction("Pintura Van Gogh", modality);

    var client1 = new Client("Cliente 1", auctionTest);
    var client2 = new Client("Cliente 2", auctionTest);
    var client3 = new Client("Cliente 3", auctionTest);


    auctionTest.StartAuction();

    client1.Auction.ReceiveBid(client1, 1000);
    client2.Auction.ReceiveBid(client2, 1100);
    client3.Auction.ReceiveBid(client3, 500);

    //act

    auctionTest.FinishAuction();

    var expectedValue = 1100;

    //assert
    var valueObtained = auctionTest.Winner.Value;

    VerifyAuction(expectedValue, valueObtained);


}

static void AuctionWithOneBid()
{
    var modality = new BidMaxValue();

    var auctionTest = new Auction("Pintura Van Gogh", modality);

    var client1 = new Client("Cliente 1", auctionTest);

    auctionTest.StartAuction();

    client1.Auction.ReceiveBid(client1, 1000);

    auctionTest.FinishAuction();

    var expectedValue = 1000;
    var valueObtained = auctionTest.Winner.Value;

    VerifyAuction(expectedValue, valueObtained);            
}

AuctionWithMultipleBids();
AuctionWithOneBid();

Console.ReadLine();