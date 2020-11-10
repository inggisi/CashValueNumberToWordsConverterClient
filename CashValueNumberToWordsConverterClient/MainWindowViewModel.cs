﻿using System;
using System.Collections.Generic;
using System.Text;
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
        

        public MainWindowViewModel()
        {
             var serverAddress = Properties.Settings.Default.ServerAddress;
            _converterGrpcClient = new CashValueConverterGrpcClient(serverAddress);
        }

        private double _cashValueAsNumber;
        public double CashValueAsNumber
        {
            get { return _cashValueAsNumber; }
            set { _cashValueAsNumber = value; RaisePropertyChanged(); }
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


        private RelayCommand _convertCashValue;
        public RelayCommand ConvertCashValue => _convertCashValue ?? (_convertCashValue = new RelayCommand(() =>
        {

            Status = string.Empty;
            var result = _converterGrpcClient.Convert(CashValueAsNumber);

            if (result.HasError)
            {
                Status = result.ErrorMessage;
                
            }

            CashValueAsWords = result.NumberAsWord;
        }));

    }
}

