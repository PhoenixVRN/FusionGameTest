using System;

public class BaseController:IController
{
   protected void AddController(IController controller)
   {
      if ( controller is IExecute execute)
      {
         ListController.ExecuteEvt += execute.Execute;
      }
   }

   protected  void RemoveController(IController controller)
   {
      if (controller is IDisposable disposable)
      {
         disposable.Dispose();
      }
      if ( controller is IExecute execute)
      {
         ListController.ExecuteEvt -= execute.Execute;
      }
   }
}

