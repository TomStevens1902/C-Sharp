using Pinger;
using System.Net.NetworkInformation;
using System.Text;

//ping DNS server 4.2.2.2
PingService pingService = new PingService();
pingService.sendPing();
Console.WriteLine();