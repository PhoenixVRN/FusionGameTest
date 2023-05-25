using System;
using UnityEngine;

public class PlayerController : IExecute, IDisposable
{
   private ViewHero _viewHero;
   private HeroModel _heroModel;
   
   public PlayerController (ViewHero viewHero, HeroModel heroModel)
   {
      _viewHero = viewHero;
      _heroModel = heroModel;
      // _viewPlayer.DestroyEvt += OnDispose;
      _viewHero.СollisionEvt += CollisionPlayerHandler;
   }

   public void Execute(float deltaTime)
   {
      // MoveHiro( deltaTime);
   }

   public void MoveHiro(float deltaTime)
   {
      // var i = _viewPlayer.transform.forward * Input.GetAxis("Vertical") * speed * deltaTime;
      // _viewPlayer.Rb.velocity = _viewPlayer.transform.forward * Input.GetAxis("Vertical") * speed * deltaTime;
      // var r = _viewPlayer.transform.up * Input.GetAxis("Horizontal") * rotateSpeed * deltaTime;
      // _viewPlayer.transform.Rotate(_viewPlayer.transform.up * Input.GetAxis("Horizontal") * rotateSpeed * deltaTime);
   }

   private void CollisionPlayerHandler(GameObject obj)
   {
      Debug.Log($"Player столкнулся с {obj}");
   }
   // private void OnDispose()
   // {
   //    _viewPlayer.DestroyEvt -= OnDispose;
   //    _viewPlayer.СollisionPlayerEvt -= CollisionPlayerHandler;
   //    InitializationGame.Execute -= Execute;
   //    GameObject.Destroy(_viewPlayer);
   // }
   public void Dispose()
   {
      
   }
}
