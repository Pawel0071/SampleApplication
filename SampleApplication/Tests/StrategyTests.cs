using SampleApplication.Model.DomainModel;
using SampleApplication.Model.CheckStrategy;
using Xunit;

namespace SampleApplication.Tests.Strategies;

public class StrategyTests
{
    private TextModel CreateModel(string text, string value, bool cs) => new()
    {
        Text = text,
        ConditionValue = value,
        IsCaseSensitivity = cs
    };

    [Theory]
    [InlineData("abc","abc",true,true)]
    [InlineData("abc","ABC",false,true)]
    [InlineData("abc","ABC",true,false)]
    public void EqualStrategy_Works(string text,string value,bool caseSensitive,bool expected)
    {
        var model = CreateModel(text,value,caseSensitive);
        var strategy = new EqualStrategy();
        Assert.Equal(expected, strategy.DoCheck(model));
    }

    [Fact]
    public void BeginsWithStrategy_Works()
    {
        var model = CreateModel("HelloWorld","Hello",false);
        Assert.True(new BeginsWithStrategy().DoCheck(model));
    }

    [Fact]
    public void EndOnStrategy_Works()
    {
        var model = CreateModel("HelloWorld","World",false);
        Assert.True(new EndOnStrategy().DoCheck(model));
    }

    [Fact]
    public void ContainsStrategy_Works()
    {
        var model = CreateModel("HelloWorld","loWo",false);
        Assert.True(new ContainsStrategy().DoCheck(model));
    }
}
