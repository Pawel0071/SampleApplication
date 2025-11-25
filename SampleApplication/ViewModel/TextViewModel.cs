using Prism.Commands;
using System.Windows.Input;
using SampleApplication.Model.Interfaces;
using SampleApplication.Model.CheckStrategy;
using SampleApplication.Model.Helper;
using SampleApplication.Model.DomainModel;
using SampleApplication.Resources;

namespace SampleApplication.ViewModel
{
    public interface ITextViewModel
    {
        string Text { get; set; }
        ConditionType Condition { get; set; }
        string Value { get; set; }
        bool IsCaseSensitive { get; set; }
        string ResultText { get; }
        System.Windows.Input.ICommand CheckCommand { get; }
        bool CanCheck { get; }
        void Check(object value);
    }

    public class TextViewModel : ViewModelBase, ITextViewModel, System.ComponentModel.INotifyDataErrorInfo
    {
        private readonly TextModel textModel;
        private readonly ICheckStrategyResolver strategyResolver;
        private bool? checkResult;
        private string resultText;
        private ICheckStrategy? checkStrategy;       
        private bool submitted;

        public TextViewModel(ICheckStrategyResolver? strategyResolver = null)
        {
            this.textModel = new TextModel();
            this.strategyResolver = strategyResolver ?? new CheckStrategyResolver();
            this.checkResult = null;
            this.ResultText = this.GetResultText();
            this.CheckCommand = new DelegateCommand<object?>(Check)
                .ObservesProperty(() => Text)
                .ObservesProperty(() => Value)
                .ObservesProperty(() => Condition)
                .ObservesProperty(() => IsCaseSensitive)
                .ObservesCanExecute(() => CanCheck);
        }

        public string Text
        { 
            get => this.textModel.Text;
            set
            {
                if (textModel.Text == value) return;
                this.textModel.Text = value;
                OnPropertyChanged();
                ResetIfNeeded();
                ErrorsChanged?.Invoke(this, new System.ComponentModel.DataErrorsChangedEventArgs(nameof(Text)));
                submitted = false;
            }
        }

        public ConditionType Condition
        {
            get => this.textModel.Condition;
            set
            {
                if (ReferenceEquals(textModel.Condition, value)) return;
                this.textModel.Condition = value;
                OnPropertyChanged();
                ResetIfNeeded();
                ErrorsChanged?.Invoke(this, new System.ComponentModel.DataErrorsChangedEventArgs(nameof(Condition)));
                submitted = false;
            }
        }

        public string Value
        {
            get => this.textModel.ConditionValue;
            set
            {
                if (textModel.ConditionValue == value) return;
                this.textModel.ConditionValue = value;
                OnPropertyChanged();
                ResetIfNeeded();
                ErrorsChanged?.Invoke(this, new System.ComponentModel.DataErrorsChangedEventArgs(nameof(Value)));
                submitted = false;
            }
        }

        public bool IsCaseSensitive
        {
            get => this.textModel.IsCaseSensitivity;
            set
            {
                if (textModel.IsCaseSensitivity == value) return;
                this.textModel.IsCaseSensitivity = value;
                OnPropertyChanged();
                ResetIfNeeded();
                ErrorsChanged?.Invoke(this, new System.ComponentModel.DataErrorsChangedEventArgs(nameof(IsCaseSensitive)));
                submitted = false;
            }
        }

        public string ResultText 
        { 
            get => this.resultText;
            private set => SetProperty(ref resultText, value);
        }

        public string GetResultText()
        {
            return this.checkResult switch
            {
                null => Strings.NoResult,
                true => Strings.PositiveResult,
                false => Strings.NegativeResult
            };          
        }

        public ICommand CheckCommand { get; set; }

        public ConditionTypeListViewModel Conditions { get; } = new ConditionTypeListViewModel();

        public bool CanCheck =>
            !string.IsNullOrEmpty(this.Text) 
            && !string.IsNullOrEmpty(this.Value) 
            && this.Condition.TypeID!=0;

        public string ToolTip => this.CanCheck ? Strings.ToolTipReady : Strings.ToolTipMissingData;

        public void SetStrategy(ICheckStrategy checkStrategy) => this.checkStrategy = checkStrategy;

        public void Check(object value)
        {
            this.SetStrategy(strategyResolver.Resolve(this.textModel.Condition));
            this.checkResult = this.checkStrategy!.DoCheck(this.textModel);
            this.ResultText = this.GetResultText();          
            submitted = true;
            ErrorsChanged?.Invoke(this, new System.ComponentModel.DataErrorsChangedEventArgs(string.Empty));
        }

        public bool HasErrors => !CanCheck;

        public bool Submitted => submitted;

        public event System.EventHandler<System.ComponentModel.DataErrorsChangedEventArgs>? ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) yield break;
            if (!Submitted) yield break;
            if (propertyName == nameof(Text) && string.IsNullOrEmpty(Text)) yield return Strings.ValidationMissingText;
            if (propertyName == nameof(Value) && string.IsNullOrEmpty(Value)) yield return Strings.ValidationMissingValue;
            if (propertyName == nameof(Condition) && (Condition?.TypeID ?? 0) == 0) yield return Strings.ValidationMissingCondition;
        }

        private void ClearResult()
        {
            checkResult = null;
            ResultText = GetResultText();
        }

        private void ResetIfNeeded()
        {
            if (checkResult.HasValue)
            {
                ClearResult();
            }
        }
    }
}
