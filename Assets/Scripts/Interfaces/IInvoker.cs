public interface IInvoker
{
    public abstract void ExecuteQueuedCommands();

    public abstract void QueueCommand(ICommand command);
}