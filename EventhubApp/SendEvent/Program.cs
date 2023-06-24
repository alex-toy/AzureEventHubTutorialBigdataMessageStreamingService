using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace SendEvent
{
    internal class Program
    {
        private const string eventHubConnectionString = "Endpoint=sb://alexeieventhub.servicebus.windows.net/;SharedAccessKeyName=sendap;SharedAccessKey=ckx0zeq5ONQ+ucAr7X5L6qG2C3urv8PeU+AEhGNdRUM=;EntityPath=eventhub1";
        private const string eventHubName = "eventhub1";
        static async Task Main()
        {
            await using (var producerClient = new EventHubProducerClient(eventHubConnectionString, eventHubName))
            {
                using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("First event")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Second event")));
                eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Third event")));

                await producerClient.SendAsync(eventBatch);
                Console.WriteLine("A batch of 3 events has been published.");
            }
        }
    }
}
