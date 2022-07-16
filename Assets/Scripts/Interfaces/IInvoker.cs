public interface IInvoker
{
    public abstract void ProcessTurn();

    public abstract void QueueCommand(ICommand command);
}