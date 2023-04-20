using SampleApplication.Commands;
using System.Windows.Input;
using SampleApplication.Model.Interfaces;
using SampleApplication.Model.Helper;
using SampleApplication.Model.DomainModel;

namespace SampleApplication.ViewModel
{
    public class TextViewModel : ViewModelBase
    {
        private TextModel textModel;
        private bool? checkResult;
        private string resultText;
        private ICheckStrategy checkStrategy;       

        public TextViewModel()
        {
            this.textModel = new TextModel();
            this.checkResult = null;
            this.ResultText = this.GetResultText();
            this.CheckCommand = new BaseCommand(Check, param => this.CanCheck);
        }

        public string Text
        { 
            get => this.textModel.Text;
            set
            {
                this.textModel.Text = value;
                OnPropertyChanged(nameof(Text));
                if (this.checkResult.HasValue)
                {
                    this.ClearResult();
                }
            }
        }

        public ConditionType Condition
        {
            get => this.textModel.Condition;
            set
            {
                this.textModel.Condition = value;
                OnPropertyChanged(nameof(Condition));
                if (this.checkResult.HasValue)
                {
                    this.ClearResult();
                }
            }
        }

        public string Value
        {
            get => this.textModel.ConditionValue;
            set
            {
                this.textModel.ConditionValue = value;
                OnPropertyChanged(nameof(Value));
                if (this.checkResult.HasValue)
                {
                    this.ClearResult();
                }
            }
        }

        public bool IsCaseSensitive
        {
            get => this.textModel.IsCaseSensitivity;
            set
            {
                this.textModel.IsCaseSensitivity = value;
                OnPropertyChanged(nameof(IsCaseSensitive));
                if (this.checkResult.HasValue)
                {
                    this.ClearResult();
                }
            }
        }

        public string ResultText 
        { 
            get => this.resultText;
            set
            {
                this.resultText = value;        
                OnPropertyChanged(nameof(ResultText));
            }
        }

        public string GetResultText()
        {
            return this.checkResult switch
            {
                null => "Brak wyniku",
                true => "Wynik sprawdzenia pozytywny",
                false => "Wynik sprawdzenia negatywny"
            };          
        }

        public ICommand CheckCommand { get; set; }

        public ConditionTypeListViewModel Conditions { get; } = new ConditionTypeListViewModel();

        public bool CanCheck =>
            !string.IsNullOrEmpty(this.Text) 
            && !string.IsNullOrEmpty(this.Value) 
            && this.Condition.TypeID!=0;

        public string ToolTip { get => "Wprowadź wszystkie wymagane dane."; }

        public void SetStrategy(ICheckStrategy checkStrategy)
        {
            this.checkStrategy = checkStrategy;
        }

        public void Check(object value)
        {
            this.SetStrategy(this.textModel.Condition.GetStrategy());
            this.checkResult = this.checkStrategy.DoCheck(this.textModel);
            this.ResultText = this.GetResultText();          
        }

        private void ClearResult()
        {
            this.checkResult = null;
            this.ResultText = this.GetResultText();
        }
    }
}
