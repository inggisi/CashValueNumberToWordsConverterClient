
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;
using CashValueNumberToWordsConverterServiceAdapter;
using CashValueNumberToWordsConverterGrpcServiceAdapter;

namespace CashValueNumberToWordsConverterClient
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<ICashValueNumberToWordsConverterServiceAdapter, CashValueNumberToWordsConverterGrpcServiceAdapter.CashValueNumberToWordsConverterGrpcServiceAdapter>();
            SimpleIoc.Default.Register<MainWindowViewModel>();

        }

        public MainWindowViewModel MainWindowViewModel => SimpleIoc.Default.GetInstance<MainWindowViewModel>();
    }
}
