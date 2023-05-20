using System;

public interface IController
{
    event Action<IController> EvtNeedDestroy;
}
