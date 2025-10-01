
// Amir Moeini Rad
// May 7, 2025

// Main Concept: Sending and Receiving a Ping Message

// .NET constructs used in this example:
// Namespace: System.Net.NetworkInformation
// Classes: Ping, PingReply
// Enumeration: IPStatus

using System.Net.NetworkInformation;

namespace PingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("A Simple Ping Program in C#.NET.");
            Console.WriteLine("--------------------------------\n");


            string host = "google.com";

            // 'Ping' class allows an application to check whether a remote host is available via the network.
            // It sends an echo message.
            Ping pingSender = new Ping();

            try
            {
                // 'PingReply' contains info about a Ping reply.
                // It is an ICMP protocol message
                // Synchronously sends the ping and waits for the reply.
                // '??' means if 'host' is null, 'www.microsoft.com' will be used as default.
                PingReply pingReply = pingSender.Send(host ?? "www.microsoft.com");

                if (pingReply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Ping was successful.");

                    #pragma warning disable CS8602 // Dereference of a possibly null reference.
                    Console.WriteLine($"Reply from {host} {pingReply.Address}: bytes={pingReply.Buffer.Length} time={pingReply.RoundtripTime}ms TTL={pingReply.Options.Ttl}");
                    #pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
                else
                {
                    Console.WriteLine($"Ping failed: {pingReply.Status}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ping failed: {ex.Message}");
            }
        }
    }
}

/*

The Ping function is provided by the ICMP protocol.
ICMP is a network layer protocol.

If you want more control over ICMP messages and packets, you can use 'Socket' instead of 'Ping'.
 
*/
