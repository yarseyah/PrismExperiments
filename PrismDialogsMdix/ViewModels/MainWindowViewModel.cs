namespace PrismDialogsMdix.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Services.Dialogs;

    using PrismDialogsMdix.Services;

    public class MainWindowViewModel : BindableBase
    {
        private int selectedFruitIndex;

        public MainWindowViewModel(IFruitService fruitService, IDialogService dialogService)
        {
            FruitService = fruitService;
            DialogService = dialogService;

            Fruits = new ObservableCollection<string>(FruitService.GetAll());

            PressMeCommand = new DelegateCommand<string>(ShowDialog);
        }

        public ICommand PressMeCommand { get; }

        public ObservableCollection<string> Fruits { get; }

        public int SelectedFruitIndex
        {
            get => selectedFruitIndex;
            set => SetProperty(ref selectedFruitIndex, value);
        }

        private IFruitService FruitService { get; }

        private IDialogService DialogService { get; }

        private void ShowDialog(string dialogToShow)
        {
            if (dialogToShow == "exampleDialog")
            {
                var message = $"selectedFruitIndex = {SelectedFruitIndex}";

                Trace.WriteLine($"Button pressed - selectedFruitIndex = {SelectedFruitIndex}");
                IDialogParameters parameters = new DialogParameters();
                parameters.Add("message", $"{dialogToShow} - {message}");
                DialogService.ShowDialog(dialogToShow, parameters, dialogResult => Trace.WriteLine($"Response from dialog was {dialogResult.Result} - {dialogResult.Parameters.GetValue<string>("data")}"));
            }
            else
            {
                DialogService.ShowDialog(
                    dialogToShow,
                    null,
                    result =>
                        {
                            if (result.Result == ButtonResult.OK)
                            {
                                var newFruit = result.Parameters.GetValue<string>("newFruit");
                                if (!string.IsNullOrWhiteSpace(newFruit))
                                {
                                    Fruits.Add(newFruit);
                                }
                            }
                        });
            }
        }
    }
}
