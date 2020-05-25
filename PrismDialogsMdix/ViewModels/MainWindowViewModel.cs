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

        public MainWindowViewModel(IFruitService fruitService)
        {
            FruitService = fruitService;
            Fruits = FruitService.GetAll();
        }

        public ICommand PressMeCommand { get; } = new DelegateCommand(() => Trace.WriteLine("Button pressed"));

        public string[] Fruits
        {
            get => this.fruits;
            set => SetProperty(ref this.fruits, value);
        }

        private IFruitService FruitService { get; }

    }
}
