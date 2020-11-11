using CashValueNumberToWordsConverterServiceAdapter;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CashValueNumberToWordsConverterGrpcServiceAdapter
{
    public class CashValueNumberToWordsConverterGrpcServiceAdapter : ICashValueNumberToWordsConverterServiceAdapter
    {
        public string ServerAddress { get; set; }
        public async Task<ConversionResult> Convert(double number)
        {
            using var channel = GrpcChannel.ForAddress(ServerAddress);
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
