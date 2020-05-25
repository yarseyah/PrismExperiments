namespace PrismDialogsMdix.ViewModels
{
    using System.Diagnostics;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Mvvm;

    public class DialogWindowViewModel : BindableBase
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
    }
}
