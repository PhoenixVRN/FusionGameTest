using System;

public abstract class ControllerBasic : IController
{

    // protected void Init()
    // {
    //     InitializationGame.Execute += Execute;
    // }
    // public  virtual void Execute(float deltaTime)
    // {
    //   
    // }
    public event Action<IController> EvtNeedDestroy;
}
