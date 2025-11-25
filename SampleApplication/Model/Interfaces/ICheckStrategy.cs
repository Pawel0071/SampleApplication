using SampleApplication.Model.DomainModel;

namespace SampleApplication.Model.Interfaces
{
    public interface ICheckStrategy
    {
        public bool DoCheck(TextModel textModel);
    }
}