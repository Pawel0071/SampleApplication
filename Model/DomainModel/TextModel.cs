namespace SampleApplication.Model.DomainModel
{
    public class TextModel
    {
        public TextModel()
        {
            Text = string.Empty;
            Condition = new ConditionType();
            ConditionValue = string.Empty;
            IsCaseSensitivity = false;
        }

        public string Text { get; set; }

        public ConditionType Condition { get; set; }

        public string ConditionValue { get; set; }

        public bool IsCaseSensitivity { get; set; }

    }
}
