using Xunit;
using SampleApplication.Model.DomainModel;
using SampleApplication.Model.CheckStrategy;

namespace SampleApplication.UnitTests;

public class StrategyTests
{
    [Fact]
    public void EqualStrategy_CaseInsensitive_Match()
    {
        var model = new TextModel { Text = "AbC", ConditionValue = "abc", IsCaseSensitivity = false };
        Assert.True(new EqualStrategy().DoCheck(model));
    }

    [Fact]
    public void BeginsWithStrategy_Match()
    {
        var model = new TextModel { Text = "HelloWorld", ConditionValue = "Hello", IsCaseSensitivity = false };
        Assert.True(new BeginsWithStrategy().DoCheck(model));
    }

    [Fact]
    public void EndOnStrategy_Match()
    {
        var model = new TextModel { Text = "HelloWorld", ConditionValue = "World", IsCaseSensitivity = false };
        Assert.True(new EndOnStrategy().DoCheck(model));
    }

    [Fact]
    public void ContainsStrategy_Match()
    {
        var model = new TextModel { Text = "HelloWorld", ConditionValue = "loWo", IsCaseSensitivity = false };
        Assert.True(new ContainsStrategy().DoCheck(model));
    }
}
