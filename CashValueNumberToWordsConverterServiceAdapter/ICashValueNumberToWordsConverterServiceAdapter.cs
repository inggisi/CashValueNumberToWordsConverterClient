using System;
using System.Threading.Tasks;

namespace CashValueNumberToWordsConverterServiceAdapter
{
    public interface ICashValueNumberToWordsConverterServiceAdapter
    {
        Task<ConversionResult> Convert(double number);
        string ServerAddress { get; set; }
    }
}
