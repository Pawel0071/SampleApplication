using SampleApplication.Model.DomainModel;
using SampleApplication.Model.Helper;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleApplication.ViewModel
{
    public class ConditionTypeListViewModel
    {
        private ObservableCollection<ConditionType> conditions;

        public ConditionTypeListViewModel()
        {
            this.conditions = new ObservableCollection<ConditionType>().Init();
        }

        public IList<ConditionType> Conditions => conditions;

    }
}
