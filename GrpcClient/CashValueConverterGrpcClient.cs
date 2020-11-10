using Grpc.Net.Client;
using System;

namespace GrpcClient
{
    public class CashValueConverterGrpcClient
    {
        public ConversionResult Convert(double number) 
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            try
            {
                var client = new NumberToWordConverter.NumberToWordConverterClient(channel);
                var reply = client.Convert(new NumberToWordConversionRequest() { NumberToConvert = number });
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
