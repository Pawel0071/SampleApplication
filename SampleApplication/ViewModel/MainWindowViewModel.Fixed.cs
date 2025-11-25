using System.Windows.Input;
using Prism.Commands;
using SampleApplication.Services;

namespace SampleApplication.ViewModel;

public interface IMainWindowViewModel
{
    System.Windows.Input.ICommand CloseCommand { get; }
    IApplicationService ApplicationService { get; }
    ITextViewModel TextViewModel { get; }
}

public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
{
    public MainWindowViewModel(ITextViewModel textViewModel, IApplicationService applicationService)
    {
        ApplicationService = applicationService;
        TextViewModel = textViewModel;
        CloseCommand = new DelegateCommand(() => ApplicationService.Shutdown());
    }

    public ICommand CloseCommand { get; }
    public IApplicationService ApplicationService { get; }
    public ITextViewModel TextViewModel { get; }
}
