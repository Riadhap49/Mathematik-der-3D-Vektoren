using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Mathematik3DVektorenLib.ViewModel;
using System.Windows;

namespace Mathematik3DVektorenApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnClose_Click(object sender, RoutedEventArgs e)
        {
            var dialogSetting = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Yes",
                NegativeButtonText = "No",
                AnimateShow = true,
                AnimateHide = true
            };
            var result = await this.ShowMessageAsync("Warning", "Are you sure, you want to close this program", MessageDialogStyle.AffirmativeAndNegative, dialogSetting);
            if (result == MessageDialogResult.Affirmative)
                Application.Current.Shutdown();
        }
        private void tglBtnMaximizeRestore_Checked(object sender, RoutedEventArgs e) =>  WindowState = WindowState.Maximized;
        

        private void tglBtnMaximizeRestore_Unchecked(object sender, RoutedEventArgs e) => WindowState = WindowState.Normal;

        private void btnMinimize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
    }
}
