using SampleApplication.ViewModel;
using SampleApplication.Services;
using SampleApplication.Model.CheckStrategy;
using Xunit;

namespace SampleApplication.Tests.ViewModels;

public class TextViewModelTests
{
    [Fact]
    public void CanCheck_False_WhenMissingData()
    {
        var vm = new TextViewModel(new CheckStrategyResolver());
        Assert.False(vm.CanCheck);
    }

    [Fact]
    public void Check_SetsResult()
    {
        var vm = new TextViewModel(new CheckStrategyResolver());
        vm.Text = "abc";
        vm.Condition = new SampleApplication.Model.DomainModel.ConditionType { TypeID = 1, TypeName = "=" };
        vm.Value = "abc";
        Assert.True(vm.CanCheck);
        vm.Check(null!);
        Assert.Contains("pozytywny", vm.ResultText);
    }
}
