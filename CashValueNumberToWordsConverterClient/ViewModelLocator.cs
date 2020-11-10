
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashValueNumberToWordsConverterClient
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainWindowViewModel>();
        }

        public MainWindowViewModel MainWindowViewModel => SimpleIoc.Default.GetInstance<MainWindowViewModel>();
    }
}
