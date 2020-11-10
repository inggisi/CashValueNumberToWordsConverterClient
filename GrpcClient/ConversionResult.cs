using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcClient
{
    public class ConversionResult
    {

        public ConversionResult()
        {
            NumberAsWord = string.Empty;
            ErrorMessage = string.Empty;
            HasError = false;
        }

        public string NumberAsWord { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }

    }
}
