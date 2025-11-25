using System.Windows;
using System.Windows.Controls;
using Prism.Ioc;
using Prism.Unity;
using SampleApplication.Services;
using SampleApplication.ViewModel;
using SampleApplication.Model.CheckStrategy;
using Prism.Modularity;
using SampleApplication.View;

namespace SampleApplication
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell() => Container.Resolve<MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationService, ApplicationService>();
            containerRegistry.Register<ICheckStrategyResolver, CheckStrategyResolver>();
            containerRegistry.Register<ITextViewModel, TextViewModel>();
            containerRegistry.Register<IMainWindowViewModel, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<TextView>("TextView");
        }

        protected override void OnInitialized()
        {
            ToolTipService.ShowOnDisabledProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(true));
            base.OnInitialized();
            var regionManager = Prism.Regions.RegionManager.GetRegionManager(Current.MainWindow);
            regionManager.RequestNavigate("MainRegion", "TextView");
            Current.MainWindow.DataContext = Container.Resolve<IMainWindowViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<SampleApplication.Modules.TextModule.TextModule>();
        }
    }
}
