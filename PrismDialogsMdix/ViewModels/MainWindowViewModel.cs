namespace PrismDialogsMdix.ViewModels
{
    using System.Diagnostics;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Services.Dialogs;

    using PrismDialogsMdix.Services;

    public class MainWindowViewModel : BindableBase
    {
        private string[] fruits;

        private int selectedFruitIndex;

        public MainWindowViewModel(IFruitService fruitService, IDialogService dialogService)
        {
            FruitService = fruitService;
            DialogService = dialogService;

            Fruits = FruitService.GetAll();

            PressMeCommand = new DelegateCommand(ShowDialog);
        }

        public ICommand PressMeCommand { get; }

        public string[] Fruits
        {
            get => fruits;
            set => SetProperty(ref this.fruits, value);
        }

        public int SelectedFruitIndex
        {
            get => selectedFruitIndex;
            set => SetProperty(ref selectedFruitIndex, value);
        }

        private IFruitService FruitService { get; }

        private IDialogService DialogService { get; }

        private void ShowDialog()
        {
            var message = $"selectedFruitIndex = {SelectedFruitIndex}";
            Trace.WriteLine($"Button pressed - selectedFruitIndex = {SelectedFruitIndex}");

            IDialogParameters parameters = new DialogParameters();
            parameters.Add("message", message);

            DialogService.ShowDialog("exampleDialog", parameters, OnDialogResult);
        }

        private void OnDialogResult(IDialogResult dialogResult)
        {
            Trace.WriteLine($"Response from dialog was {dialogResult.Result}");
        }
    }
}
