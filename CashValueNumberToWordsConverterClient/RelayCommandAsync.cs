using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CashValueNumberToWordsConverterClient
{
    public class RelayCommandAsync : ICommandAsync
    {
        private readonly Func<Task> _executeHandler;
        private readonly Func<bool> _canExecuteHandler;
        private readonly Action<Exception> _errorHandler;
        private bool _isRunning;
        public event EventHandler CanExecuteChanged;

        public RelayCommandAsync(Func<Task> execute, Func<bool> canExecute, Action<Exception> errorHandler)
        {
            _executeHandler = execute;
            _canExecuteHandler = canExecute;
            _errorHandler = errorHandler;
        }

        #region ICommand

        public bool CanExecute(object parameter) => _canExecuteHandler == null ? true : _canExecuteHandler();
        public void Execute(object parameter)
        {
            ExecuteAsync();
        }
        #endregion

        #region ICommandAsync
        public async Task ExecuteAsync()
        {
            if (CanExecute())
            {
                try
                {
                    _isRunning = true;
                    await _executeHandler();
                }
                catch (Exception ex)
                {
                    _errorHandler?.Invoke(ex);
                }
                finally
                {
                    _isRunning = false;
                }
            }
            CanExecuteChanged.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute()
        {
            return !_isRunning && (_canExecuteHandler?.Invoke() ?? true);
        }
        #endregion


    }
}
