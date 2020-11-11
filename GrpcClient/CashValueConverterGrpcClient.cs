using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    public class CashValueConverterGrpcClient
    {

        private readonly string _serverAddress;

        public CashValueConverterGrpcClient(string serverAddress)
        {
            _serverAddress = serverAddress;
        }


        public async Task<ConversionResult> Convert(double number) 
        {
            using var channel = GrpcChannel.ForAddress(_serverAddress);
            try
            {
                var client = new NumberToWordConverter.NumberToWordConverterClient(channel);
                var reply = await client.ConvertAsync(new NumberToWordConversionRequest() { NumberToConvert = number });
                return new ConversionResult()
                {
                    NumberAsWord = reply.ConvertedNumber,
                    ErrorMessage = reply.ErrorMessage,
                    HasError = (!string.IsNullOrEmpty(reply.ErrorMessage))
                };
            }
            catch (Exception ex)
            {
                return new ConversionResult()
                {
                    ErrorMessage = ex.Message,
                    HasError = true
                };
            }
        }
    }
}
