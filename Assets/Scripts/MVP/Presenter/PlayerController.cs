using UnityEngine;

public class PlayerController : IExecute
{
   private ViewPlayer _viewPlayer;
   private HeroModel _heroModel;
   
   public PlayerController (ViewPlayer viewPlayer, HeroModel heroModel)
   {
      _viewPlayer = viewPlayer;
      _heroModel = heroModel;
   }

   public void Init()
   {
      _viewPlayer.DestroyEvt += OnDispose;
      _viewPlayer.СollisionPlayerEvt += CollisionPlayerHandler;
   }

   public void Execute(float deltaTime)
   {
      MoveHiro(_heroModel.SpeedMove, _heroModel.SpeedRotate, deltaTime);
   }

   public void MoveHiro(int speed, int rotateSpeed, float deltaTime)
   {
      _viewPlayer.Rb.velocity = _viewPlayer.transform.forward * Input.GetAxis("Vertical") * speed * deltaTime;
      _viewPlayer.transform.Rotate(_viewPlayer.transform.up * Input.GetAxis("Horizontal") * rotateSpeed * deltaTime);
   }

   private void CollisionPlayerHandler(string name)
   {
      Debug.Log($"Player столкнулся с {name}");
   }
   private void OnDispose()
   {
      _viewPlayer.DestroyEvt -= OnDispose;
      _viewPlayer.СollisionPlayerEvt -= CollisionPlayerHandler;
   }
}
