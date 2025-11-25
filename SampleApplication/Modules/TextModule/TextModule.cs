using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SampleApplication.View;

namespace SampleApplication.Modules.TextModule;

public class TextModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<IRegionManager>();
        regionManager.RequestNavigate("MainRegion", "TextView");
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<TextView>("TextView");
    }
}
