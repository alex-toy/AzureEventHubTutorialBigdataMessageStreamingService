using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Processor;

namespace ReceiveEvent
{
    internal class Program
    {
        private const string eventHubConnectionString = "Endpoint=sb://alexeieventhub.servicebus.windows.net/;SharedAccessKeyName=receiveap;SharedAccessKey=nkZDD90kKpvH/j/Y1ufDNgFw/g6kmFSkM+AEhE3NWVE=;EntityPath=eventhub1";
        private const string eventHubName = "eventhub1";

        private const string blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=alexeiappstore;AccountKey=ZD/1Fbx1Ef5UCp7nlX/0RITsS82/ymx9n/8v48Q9YoQmk16fAoxcdOBQCOnl+qiZBvswOEp57FbH+AStGvmjpg==;EndpointSuffix=core.windows.net";
        private const string blobContainerName = "data";

        static async Task Main()
        {
            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            BlobContainerClient storageClient = new BlobContainerClient(blobStorageConnectionString, blobContainerName);

            EventProcessorClient processor = new EventProcessorClient(storageClient, consumerGroup, eventHubConnectionString, eventHubName);

            processor.ProcessEventAsync += ProcessEventHandler;
            processor.ProcessErrorAsync += ProcessErrorHandler;

            await processor.StartProcessingAsync();

            await Task.Delay(TimeSpan.FromSeconds(10));

            await processor.StopProcessingAsync();
        }

        static async Task ProcessEventHandler(ProcessEventArgs eventArgs)
        {
            Console.WriteLine("\tReceived event: {0}", Encoding.UTF8.GetString(eventArgs.Data.Body.ToArray()));
            await eventArgs.UpdateCheckpointAsync(eventArgs.CancellationToken);
        }

        static Task ProcessErrorHandler(ProcessErrorEventArgs eventArgs)
        {
            Console.WriteLine($"\tPartition '{ eventArgs.PartitionId}': an unhandled exception was encountered. This was not expected to happen.");
            Console.WriteLine(eventArgs.Exception.Message);
            return Task.CompletedTask;
        }
    }
}
