using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Pinger
{
    //abstraction
    public class PingService
    {
        public string data {  get; set; }
        public byte[] buffer { get; set; }
        public int timeout { get; set; }
        public string address { get; set; }
        public Ping pingSender { get; set; }
        public PingOptions pingOptions { get; set; }

        public PingService() //constructor 
        {
            data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            timeout = 120;
            address = "4.2.2.2";
            buffer = Encoding.ASCII.GetBytes(data);
            pingSender = new Ping();
            pingOptions = new PingOptions();

            pingOptions.DontFragment = true;
        }

        public bool sendPing()
        {
            PingReply reply = pingSender.Send(address,timeout,buffer,pingOptions);
            if (reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", reply.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                return true;
            } 
            else
            {
                return false;
            }
        }
    }
}
