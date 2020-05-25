namespace PrismDialogsMdix.Services
{
    using System;
    using System.Transactions;
    using System.Windows;

    using MaterialDesignThemes.Wpf;

    using Prism.Common;
    using Prism.Ioc;
    using Prism.Services.Dialogs;

    public class CustomDialogService : IDialogService
    {
        public CustomDialogService(IContainerExtension containerExtension, ICustomDialogHost customHost)
        {
            ContainerExtension = containerExtension;
            CustomHost = customHost;
        }

        private IContainerExtension ContainerExtension { get; }

        private ICustomDialogHost CustomHost { get; }

        public void Show(string name, IDialogParameters parameters, Action<IDialogResult> callback)
        {
            throw new NotImplementedException();
        }

        public void ShowDialog(string name, IDialogParameters parameters, Action<IDialogResult> callback)
        {
            ShowDialogInternal(name, parameters, callback);
        }

        private void ShowDialogInternal(string name, IDialogParameters parameters, Action<IDialogResult> callback)
        {
            var content = ContainerExtension.Resolve<object>(name);

            var dialogContent = content as FrameworkElement ?? throw new NullReferenceException("A dialog's content must be a FrameworkElement");
            var viewModel = dialogContent.DataContext as IDialogAware ?? throw new NullReferenceException("A dialog's ViewModel must be IDialogAware");

            MvvmHelpers.ViewAndViewModelAction<IDialogAware>(viewModel, d => d.OnDialogOpened(parameters));

            var host = CustomHost.Host
                       ?? throw new NullReferenceException("Dialog host must be specified in the ICustomDialogHost");

            // Lazy show
            host.IsOpen = true;
            host.DialogContent = dialogContent;

            viewModel.RequestClose += r =>
                {
                    host.IsOpen = false;
                    callback?.Invoke(r);
                };
        }
    }
}
