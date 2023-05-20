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
      MoveHiro(_heroModel.SpeedMove, _heroModel.SpeedRotate);
   }

   public void Execute(float deltaTime)
   {
      MoveHandler();
   }

   public void MoveHiro(int speed, int rotateSpeed)
   {
      _viewPlayer.Rb.velocity = (_viewPlayer.transform.forward * Input.GetAxis("Vertical")) * speed * Time.deltaTime;
      _viewPlayer.transform.Rotate(_viewPlayer.transform.up * Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
   }
   
   private void OnDispose()
   {
      // ListController.RemoveExecute(this);
   }
}
