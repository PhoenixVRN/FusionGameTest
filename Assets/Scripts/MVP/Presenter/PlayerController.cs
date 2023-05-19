using UnityEngine;

public class PlayerController
{
   private ViewPlayer _viewPlayer;
   private HiroModel _hiroModel;
   
   public PlayerController (ViewPlayer viewPlayer, HiroModel hiroModel)
   {
      _viewPlayer = viewPlayer;
      _hiroModel = hiroModel;
   }

   public void MoveHandler(Vector3 movein)
   {
      var move = movein * Time.deltaTime * _hiroModel.SpeedMove;
      _viewPlayer.MoveHiro(move);
   }
}
