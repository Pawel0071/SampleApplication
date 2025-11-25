using SampleApplication.Model.CheckStrategy;
using SampleApplication.Model.DomainModel;
using SampleApplication.Model.Interfaces;
using System.Collections.ObjectModel;

namespace SampleApplication.Model.Helper
{
    public static class ConditionTypeHelper
    {
        public static ObservableCollection<ConditionType> Init(this ObservableCollection<ConditionType> colection)
        {
            return new ObservableCollection<ConditionType>()
            {
                new ConditionType {TypeID = 1, TypeName ="równa się"},
                new ConditionType {TypeID = 2, TypeName ="zaczyna się od"},
                new ConditionType {TypeID = 3, TypeName = "kończy się na" },
                new ConditionType {TypeID = 4, TypeName = "zawiera" },
            };
        }
    }
}
