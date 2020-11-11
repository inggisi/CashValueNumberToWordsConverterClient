using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Navigation;
using CashValueNumberToWordsConverterClient.Properties;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GrpcClient;

namespace CashValueNumberToWordsConverterClient
{
    public class MainWindowViewModel : ViewModelBase
    {
        CashValueConverterGrpcClient _converterGrpcClient;
        public ICommandAsync ConvertCashValue { get; }

        public MainWindowViewModel()
        {
            var serverAddress = Properties.Settings.Default.ServerAddress;
            _converterGrpcClient = new CashValueConverterGrpcClient(serverAddress);
            ConvertCashValue = new RelayCommandAsync(Convert, CanConvert, HandleError);
        }


        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            private set { _isBusy = value; RaisePropertyChanged(); }
        }

        private double _cashValueAsNumber;
        public double CashValueAsNumber
        {
            get { return _cashValueAsNumber; }
            set
            {
                _cashValueAsNumber = value;
                CashValueAsWords = "";
                Status = "";
                RaisePropertyChanged();
            }
        }

        private string _cashValueAsWords;
        public string CashValueAsWords
        {
            get { return _cashValueAsWords; }
            set { _cashValueAsWords = value; RaisePropertyChanged(); }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged(); }
        }

        private async Task Convert()
        {
            Status = "Conversion is running... Please wait!";
            IsBusy = true;
            try
            {
                var result = await _converterGrpcClient.Convert(CashValueAsNumber);

                if (result.HasError)
                {
                    Status = result.ErrorMessage;

                }

                CashValueAsWords = result.NumberAsWord;
                Status = "Conversion was finished...";
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanConvert() => !IsBusy;

        private void HandleError(Exception ex)
        {
            Status = ex.Message;
        }

    }
}

