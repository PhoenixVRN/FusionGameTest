using System.Collections.Generic;
using UnityEngine;

public class PlayerController : IExecute
{
   private ViewPlayer _viewPlayer;
   private HeroModel _heroModel;
   
   public PlayerController (ViewPlayer viewPlayer, HeroModel heroModel)
   {
      _viewPlayer = viewPlayer;
      _heroModel = heroModel;
      // ListController.AddExecute(this);
      // _viewPlayer?.DestroyEvt += OnDispose();
   }

   public void MoveHandler()
   {
      _viewPlayer.MoveHiro(_heroModel.SpeedMove, _heroModel.SpeedRotate);
   }

   public void Execute(float deltaTime)
   {
      Debug.Log("nhfv hfhfh");
   }

   private void OnDispose()
   {
      // ListController.RemoveExecute(this);
   }
}
