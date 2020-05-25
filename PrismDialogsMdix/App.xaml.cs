namespace PrismDialogsMdix
{
    using System.Windows;

    using Prism.DryIoc;
    using Prism.Ioc;

    using PrismDialogsMdix.Services;
    using PrismDialogsMdix.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFruitService, FruitService>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}
