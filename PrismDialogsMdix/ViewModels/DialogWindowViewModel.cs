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
        private string message = "Hello world";

        private string title = "Dialog box";

        private ICommand closeDialogCommand;

        public DialogWindowViewModel()
        {
        }

        private static void CloseDialog()
        {
            Trace.WriteLine("To do close");
        }

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public ICommand CloseDialogCommand => closeDialogCommand ??= new DelegateCommand<string>(CloseDialog);

        public event Action<IDialogResult> RequestClose;

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        private void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            switch (parameter?.ToLower())
            {
                case "true":
                    result = ButtonResult.OK;
                    break;
                default:
                    result = ButtonResult.Cancel;
                    break;
            }

            IDialogParameters parameters = new DialogParameters();
            parameters.Add("data", parameter);
            RequestClose?.Invoke(new DialogResult(result, parameters));
        }
    }
}
