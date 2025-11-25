using System.Windows;

namespace SampleApplication.Services;

public class ApplicationService : IApplicationService
{
    public void Shutdown() => Application.Current.Shutdown();
}
