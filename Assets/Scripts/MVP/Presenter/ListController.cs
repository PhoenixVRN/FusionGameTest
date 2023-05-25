using System;

public static class ListController
{
   public static event Action<float> ExecuteEvt;

   public static void UpDate(float deltatime)
   {
      ExecuteEvt?.Invoke(deltatime);
   }
}
