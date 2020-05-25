namespace PrismDialogsMdix.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Services.Dialogs;

    public class DialogWindowViewModel : BindableBase, IDialogAware
    {
        private string message;

        public DialogWindowViewModel()
        {
            CloseDialogCommand = new DelegateCommand(() => Trace.WriteLine("To do close"));
        }

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public ICommand CloseDialogCommand { get; }

        public bool CanCloseDialog()
        {
            throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            throw new NotImplementedException();
        }

        public string Title { get; }

        public event Action<IDialogResult> RequestClose;
    }
}
