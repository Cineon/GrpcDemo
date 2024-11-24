using Grpc.Core;

namespace GrpcServer.Services
{
    public class NumberAggregatorService : NumberAggregator.NumberAggregatorBase
    {
        public override async Task<SumResponse> CalculateSum(IAsyncStreamReader<NumberRequest> requestStream, ServerCallContext context)
        {
            int sum = 0;

            // Aggregating every number from the client-side stream.
            await foreach (var numberRequest in requestStream.ReadAllAsync())
            {
                sum += numberRequest.Number;
                Console.WriteLine($"Received: {numberRequest.Number}");
            }

            Console.WriteLine($"Sent sum of: {sum}");
            return new SumResponse { Sum = sum };
        }
    }
}
