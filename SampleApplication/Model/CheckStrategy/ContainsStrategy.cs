using SampleApplication.Model.DomainModel;
using SampleApplication.Model.Interfaces;
using System;

namespace SampleApplication.Model.CheckStrategy
{
    public class ContainsStrategy : ICheckStrategy
    {
        private bool contains(string str, string substring, StringComparison comp)
        {
            return str.IndexOf(substring, comp) >= 0;
        }

        public bool DoCheck(TextModel textModel)
        {
            return contains(textModel.Text, textModel.ConditionValue, textModel.IsCaseSensitivity ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
        }
    }
}
