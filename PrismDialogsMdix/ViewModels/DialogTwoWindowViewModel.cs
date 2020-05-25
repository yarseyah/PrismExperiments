namespace PrismDialogsMdix.ViewModels
{
    using System;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Services.Dialogs;

    public class DialogTwoWindowViewModel : BindableBase, IDialogAware
    {
        private string message = "Hello world";

        private string title = "Dialog box";

        private ICommand okDialogCommand;

        private ICommand cancelDialogCommand;

        private string newFruitName;

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

        public ICommand CancelCommand =>
            cancelDialogCommand ??= new DelegateCommand(() => CloseDialog(false));

        public ICommand OkCommand =>
            okDialogCommand ??=
                new DelegateCommand(() => CloseDialog(true), () => !string.IsNullOrWhiteSpace(NewFruitName))
                    .ObservesProperty(() => NewFruitName);

        public string NewFruitName
        {
            get => newFruitName;
            set => SetProperty(ref newFruitName, value);
        }

        public event Action<IDialogResult> RequestClose;

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        private void CloseDialog(bool result)
        {
            var buttonResult = result ? ButtonResult.OK : ButtonResult.Cancel;

            IDialogParameters parameters = new DialogParameters
                                               {
                                                   { "newFruit", result ? NewFruitName : string.Empty }
                                               };

            RequestClose?.Invoke(new DialogResult(buttonResult, parameters));
        }
    }
}
