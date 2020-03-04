 using System;
using System.Text;
using System.Threading;
using Microsoft.ServiceBus.Messaging;

namespace EVENTHUB
{
    class Program
    {
    static string eventHubName = "test";
    static string connectionString = "";
        static void Main(string[] args)
        {
           SendingRandomMessages();
           Console.ReadLine();
        }
      static void SendingRandomMessages()
    {
      
      var eventHubClient =EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
      while(true)
      {
        try
        {
          var message = Guid.NewGuid().ToString();
          Console.WriteLine("{0} Sending message: {1}",DateTime.Now,message);
          eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(message)));
        }
        catch(Exception ex)
        {
          Console.WriteLine(ex.Message);
        }

        
      }
    }


    }
}
