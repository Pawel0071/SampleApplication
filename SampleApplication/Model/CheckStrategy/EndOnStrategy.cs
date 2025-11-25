using SampleApplication.Model.DomainModel;
using SampleApplication.Model.Interfaces;
using System;

namespace SampleApplication.Model.CheckStrategy
{
    public class EndOnStrategy : ICheckStrategy
    {
        public bool DoCheck(TextModel textModel)
        {
            return textModel.Text.EndsWith(textModel.ConditionValue, textModel.IsCaseSensitivity ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
        }
    }
}
