
namespace ThreadQueueManager
{
    public interface IDelayedCommand : ICommand
    {
        int millisecondsFromExecution();
    }
}
