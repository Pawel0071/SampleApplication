using SampleApplication.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace SampleApplication
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {    
                DataContext = new TextViewModel()
            };

            ToolTipService.ShowOnDisabledProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(true));

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
