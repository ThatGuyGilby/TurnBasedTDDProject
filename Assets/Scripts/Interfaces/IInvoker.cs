public interface IInvoker
{
    #region Public Methods

    public abstract void ExecuteQueuedCommands();

    public abstract void QueueCommand(ICommand command);

    #endregion Public Methods
}