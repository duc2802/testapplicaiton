namespace ThreadQueueManager
{
    public interface IQueueInterface<T>
    {
        int Count { get; }

        void Push(T obj);
        T Pop();

        void Close();
    }
}
