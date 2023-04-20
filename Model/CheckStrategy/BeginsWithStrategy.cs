using SampleApplication.Model.DomainModel;
using SampleApplication.Model.Interfaces;
using System;

namespace SampleApplication.Model.CheckStrategy
{
    public class BeginsWithStrategy : ICheckStrategy
    {
        public bool DoCheck(TextModel textModel)
        {
            return textModel.Text.StartsWith(textModel.ConditionValue, textModel.IsCaseSensitivity ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
        }
    }
}
