using UnityEngine;

public class NPSHeroController : ControllerBasic , IExecute
{
   private HeroModel _npcHeroModel;
   private ViewNPCHiro _viewNpcHero;

   private Vector3 _target = Vector3.zero;
   private Vector3 _direction;
   

   public NPSHeroController(ViewNPCHiro viewNpcHero, HeroModel npcHeroModel)
   {
      _npcHeroModel = npcHeroModel;
      _viewNpcHero = viewNpcHero;
      _viewNpcHero.СollisionNPCEvt += CollisionHandler;
      _target = UtilMVP.GetRandomSpawnPoint();
   }
   
   private void MovementNPC(float deltaTime)
   {
      if (Vector3.Distance(_viewNpcHero.transform.position, _target) < 1f)
      {
         _target = UtilMVP.GetRandomSpawnPoint();
         _viewNpcHero.transform.LookAt(_target);
      }
      else
      {
         _direction = (_target - _viewNpcHero.transform.position).normalized;
         _viewNpcHero.Rb.MovePosition(_viewNpcHero.transform.position + _direction * deltaTime * _npcHeroModel.SpeedMove);
      }
   }

   

   public  void Execute(float deltaTime)
   {
      MovementNPC(deltaTime);
   }

   private void Dispose()
   {
      // Lstc.Execute -= Execute;
      _viewNpcHero.СollisionNPCEvt -= CollisionHandler;
      _npcHeroModel = null;
      GameObject.Destroy(_viewNpcHero.gameObject);
   }

   private void CollisionHandler(string name)
   {
      Debug.Log($"NPS Bump {name}");
      if (name == "Hero(Clone)")
      {
         _npcHeroModel.ChangeHP(5);
         // Debug.Log($"Осталось ХП {_npcHeroModel.HP}");
      }
   }
}
