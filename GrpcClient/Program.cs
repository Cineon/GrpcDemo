using Grpc.Net.Client;
using GrpcServer;
using Microsoft.Extensions.Configuration;

Console.WriteLine("I am GrpcClient\n");

// Unrelated - configuring appsettings.json
var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
IConfiguration config = builder.Build();

// Set channel and client
var channel = GrpcChannel.ForAddress(config["GrpcChannels:Channel_2"]!);
var client = new NumberAggregator.NumberAggregatorClient(channel);

// Populate array with random numbers
Random random = new Random();
int[] numbersArray = new int[5];
for (int i = 0; i < 5; i++)
{
    numbersArray[i] = random.Next(1, 100);
}

using (var call = client.CalculateSum())
{
    // Sending stream of numbers
    foreach (var number in numbersArray)
    {
        await Task.Delay(3000); // 3 seconds of delay
        await call.RequestStream.WriteAsync(new NumberRequest { Number = number });
        Console.WriteLine($"Sent: {number}");
    }

    // Closing the stream
    await call.RequestStream.CompleteAsync();

    // Receiving response from the server
    var response = await call.ResponseAsync;
    Console.WriteLine($"Received sum of: {response.Sum}");
}
Console.ReadLine();