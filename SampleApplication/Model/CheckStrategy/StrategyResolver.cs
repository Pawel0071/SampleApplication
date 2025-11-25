using SampleApplication.Model.Interfaces;
using SampleApplication.Model.DomainModel;
using SampleApplication.Model.CheckStrategy;

namespace SampleApplication.Model.CheckStrategy;

public interface ICheckStrategyResolver
{
    ICheckStrategy Resolve(ConditionType conditionType);
}

public sealed class CheckStrategyResolver : ICheckStrategyResolver
{
    public ICheckStrategy Resolve(ConditionType conditionType)
    {
        return conditionType.TypeID switch
        {
            1 => new EqualStrategy(),
            2 => new BeginsWithStrategy(),
            3 => new EndOnStrategy(),
            4 => new ContainsStrategy(),
            _ => new NullStrategy()
        };
    }
}

public sealed class NullStrategy : ICheckStrategy
{
    public bool DoCheck(TextModel textModel) => false;
}
