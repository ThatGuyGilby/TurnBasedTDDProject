public interface IInvoker
{
    public abstract void QueueCommand(ICommand command);
    public abstract void ExecuteQueuedCommands();
}
