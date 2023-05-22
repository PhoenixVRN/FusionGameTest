using DG.Tweening;
using UnityEngine;


public class NPSHeroController : ControllerBasic , IExecute
{
   private NPCHeroModel _npcHeroModel;
   private ViewNPCHiro _viewNpcHero;

   private Vector3 _target = Vector3.zero;
   private Vector3 _direction;
   

   public NPSHeroController(ViewNPCHiro viewNpcHero, NPCHeroModel npcHeroModel)
   {
      _npcHeroModel = npcHeroModel;
      _viewNpcHero = viewNpcHero;
   }

   public void Init()
   {
      _viewNpcHero.СollisionNPCEvt += CollisionHandler;
      _viewNpcHero.DestroyEvt += Dispose;
      _target = Target();

   }

   private Vector3 Target()
   {
      return new Vector3(Random.Range(-_npcHeroModel.RadiusMove, _npcHeroModel.RadiusMove),
         0.3f, Random.Range(-_npcHeroModel.RadiusMove, _npcHeroModel.RadiusMove));
   }

   private void MovementNPC(float deltaTime)
   {
      _viewNpcHero.Rb.MovePosition(_viewNpcHero.transform.position + _direction * deltaTime * _npcHeroModel.SpeedMove);
   }

   public  void Execute(float deltaTime)
   {
      if (Vector3.Distance(_viewNpcHero.transform.position, _target) < 1f)
      {
         _target = Target();
      }
      else
      {
          _direction = (_target - _viewNpcHero.transform.position).normalized;
          MovementNPC(deltaTime);
      }
   }

   private void Dispose()
   {
      InitializationGame.Execute -= Execute;
      _viewNpcHero.СollisionNPCEvt -= CollisionHandler;
      _viewNpcHero.DestroyEvt -= Dispose;
   }

   private void CollisionHandler(string name)
   {Debug.Log($" NPC Столкнулись с {name}");
   }
}
