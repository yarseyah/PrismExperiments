namespace PrismDialogsMdix.ViewModels
{
    using System;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Services.Dialogs;

    public class DialogWindowViewModel : BindableBase, IDialogAware
    {
        private string message = "Hello world";

        private string title = "Dialog box";

        private ICommand closeDialogCommand;

        private bool preventClose = false;

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

        public bool PreventClose
        {
            get => preventClose;
            set => SetProperty(ref preventClose, value);
        }

        public ICommand CloseDialogCommand =>
            closeDialogCommand ??=
                new DelegateCommand<string>(CloseDialog, s => CanCloseDialog()).ObservesProperty(() => PreventClose);

        public event Action<IDialogResult> RequestClose;

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }

        public bool CanCloseDialog() => !PreventClose;

        public void OnDialogClosed()
        {
        }

        private void CloseDialog(string parameter)
        {
            var result = parameter?.ToLower() switch
                {
                    "true" => ButtonResult.OK,
                    "false" => ButtonResult.Cancel,
                    _ => ButtonResult.Cancel
                };

            IDialogParameters parameters = new DialogParameters
            {
                { "data", result == ButtonResult.OK || result == ButtonResult.Yes ? parameter : string.Empty }
            };

            RequestClose?.Invoke(new DialogResult(result, parameters));
        }
    }
}
