// See https://aka.ms/new-console-template for more information
using Alura.OnlineAuction;

var auctionTest = new Auction("Pintura Van Gogh");

var client1 = new Client("Cliente 1", auctionTest);
var client2 = new Client("Cliente 2", auctionTest);
var client3 = new Client("Cliente 3", auctionTest);

client1.Auction.ReceiveBid(client1, 1000);
client2.Auction.ReceiveBid(client2, 1100);
client3.Auction.ReceiveBid(client3, 500);

auctionTest.FinishTrading();

Console.WriteLine($"Vencedor: {auctionTest.Winner.Client.Name}");
Console.WriteLine($"Valor: {auctionTest.Winner.Value}");

Console.ReadLine();