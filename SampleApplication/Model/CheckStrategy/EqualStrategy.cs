using SampleApplication.Model.DomainModel;
using SampleApplication.Model.Interfaces;
using System;

namespace SampleApplication.Model.CheckStrategy
{
    public class EqualStrategy : ICheckStrategy
    {
        public bool DoCheck(TextModel textModel)
        {
            return string.Compare(textModel.Text, textModel.ConditionValue, textModel.IsCaseSensitivity ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
