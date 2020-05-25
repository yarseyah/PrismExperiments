namespace PrismDialogsMdix.Views
{
    using System.Windows;

    using Prism.Services.Dialogs;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDialogWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public IDialogResult Result { get; set; }
    }
}
