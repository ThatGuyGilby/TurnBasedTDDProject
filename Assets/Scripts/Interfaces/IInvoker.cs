using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInvoker
{
    public abstract void QueueCommand(ICommand command);
    public abstract void ExecuteQueuedCommands();
}
