
namespace ThreadQueueManager
{
    public interface ICommand
    {
        ExecuteMethod IsSeparate();
        string GetName();
        void Execute();

        int Priority { get; }
    }
}
