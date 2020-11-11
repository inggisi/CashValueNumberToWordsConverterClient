using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CashValueNumberToWordsConverterClient
{
    public interface ICommandAsync:ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
