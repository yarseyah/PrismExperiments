namespace PrismDialogsMdix
{
    using System.Windows;

    using MaterialDesignThemes.Wpf;

    using Prism.DryIoc;
    using Prism.Ioc;
    using Prism.Services.Dialogs;

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
            containerRegistry.RegisterDialog<Views.DialogWindow>("exampleDialog");
            containerRegistry.RegisterDialog<Views.DialogTwoWindow>("exampleDialog2");

            containerRegistry.RegisterSingleton<ICustomDialogHost, CustomDialogHost>();
            containerRegistry.Register<IDialogService, CustomDialogService>();
        }

        protected override Window CreateShell()
        {
            var mainWindow = Container.Resolve<MainWindow>();

            var dialogHost = Container.Resolve<ICustomDialogHost>();
            dialogHost.Host = mainWindow.DialogHost;

            return mainWindow;
        }
    }

    public class CustomDialogHost : ICustomDialogHost
    {
        public DialogHost Host { get; set; }
    }

    public interface ICustomDialogHost
    {
        DialogHost Host { get; set; }
    }
}
