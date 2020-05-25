namespace PrismDialogsMdix.ViewModels
{
    using System.Diagnostics;
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Mvvm;

    using PrismDialogsMdix.Services;

    public class MainWindowViewModel : BindableBase
    {
        private string[] fruits;

        private int selectedFruitIndex;

        public MainWindowViewModel(IFruitService fruitService)
        {
            FruitService = fruitService;
            Fruits = FruitService.GetAll();

            PressMeCommand = new DelegateCommand(() => Trace.WriteLine($"Button pressed - selectedFruitIndex = {SelectedFruitIndex}"));
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
    }
}
