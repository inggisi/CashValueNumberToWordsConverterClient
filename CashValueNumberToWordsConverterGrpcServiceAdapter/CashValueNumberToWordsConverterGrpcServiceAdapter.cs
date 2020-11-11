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
            GrpcChannel channel = null;

            try
            {
                channel = CreateChannel(ServerAddress);
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
            finally
            {
                if (channel != null)
                {
                    channel.Dispose();
                }
            }
        }

        private GrpcChannel CreateChannel(string serverAddress)
        {
            GrpcChannel channel;

            if (string.IsNullOrEmpty(serverAddress))
            {
                throw new Exception($"Error while creating GrpcChannel. Server address is empty. Please insert a valid address into the application settings!");
            }

            try
            {
                channel = GrpcChannel.ForAddress(ServerAddress);
                return channel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating GrpcChannel for serveraddress {serverAddress}!", ex);
            }
        }
    }
}
