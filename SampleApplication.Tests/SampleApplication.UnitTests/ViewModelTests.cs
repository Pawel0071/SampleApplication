using Moq;
using Xunit;
using SampleApplication.ViewModel;
using SampleApplication.Model.CheckStrategy;
using SampleApplication.Model.DomainModel;
using SampleApplication.Services;

namespace SampleApplication.UnitTests;

public class ViewModelTests
{
    [Fact]
    public void TextViewModel_Check_Positive_Result()
    {
        var resolver = new Mock<ICheckStrategyResolver>();
        resolver.Setup(r => r.Resolve(It.IsAny<ConditionType>())).Returns(new EqualStrategy());

        var vm = new TextViewModel(resolver.Object);
        vm.Text = "abc";
        vm.Value = "abc";
        vm.Condition = new ConditionType { TypeID = 1, TypeName = "=" };

        Assert.True(vm.CanCheck);
        vm.Check(null!);
        Assert.Contains("pozytywny", vm.ResultText);
    }

    [Fact]
    public void TextViewModel_Check_Negative_Result()
    {
        var resolver = new Mock<ICheckStrategyResolver>();
        resolver.Setup(r => r.Resolve(It.IsAny<ConditionType>())).Returns(new EqualStrategy());

        var vm = new TextViewModel(resolver.Object);
        vm.Text = "abc";
        vm.Value = "xyz";
        vm.Condition = new ConditionType { TypeID = 1, TypeName = "=" };

        Assert.True(vm.CanCheck);
        vm.Check(null!);
        Assert.Contains("negatywny", vm.ResultText);
    }

    [Fact]
    public void TextViewModel_Result_Reset_On_Input_Change()
    {
        var resolver = new Mock<ICheckStrategyResolver>();
        resolver.Setup(r => r.Resolve(It.IsAny<ConditionType>())).Returns(new EqualStrategy());
        var vm = new TextViewModel(resolver.Object)
        {
            Text = "abc",
            Value = "abc",
            Condition = new ConditionType { TypeID = 1, TypeName = "=" }
        };
        vm.Check(null!);
        Assert.DoesNotContain("Brak wyniku", vm.ResultText);
        vm.Text = "abcd";
        Assert.Equal("Brak wyniku", vm.ResultText);
    }

    [Fact]
    public void NullStrategy_Returns_False()
    {
        var vm = new TextViewModel(new CheckStrategyResolver());
        vm.Text = "abc";
        vm.Value = "abc";
        vm.Condition = new ConditionType { TypeID = 0, TypeName = "unknown" };
        Assert.False(vm.CanCheck);
    }

    [Fact]
    public void TextViewModel_CanCheck_Requires_All_Data()
    {
        var vm = new TextViewModel(new CheckStrategyResolver());
        Assert.False(vm.CanCheck);
        vm.Text = "abc";
        Assert.False(vm.CanCheck);
        vm.Value = "abc";
        Assert.False(vm.CanCheck);
        vm.Condition = new ConditionType { TypeID = 1, TypeName = "=" };
        Assert.True(vm.CanCheck);
    }

    [Fact]
    public void MainWindowViewModel_CloseCommand_ShutsDown()
    {
        var appService = new Mock<IApplicationService>();
        var textVm = new Mock<ITextViewModel>();
        var vm = new MainWindowViewModel(textVm.Object, appService.Object);
        vm.CloseCommand.Execute(null);
        appService.Verify(a => a.Shutdown(), Times.Once);
    }
}
