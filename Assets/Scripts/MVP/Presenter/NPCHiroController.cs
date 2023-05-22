using DG.Tweening;
using UnityEngine;

public class NPSHeroController : ControllerBasic , IExecute
{
   private NPCHeroModel _npcHeroModel;
   private ViewNPCHiro _viewNpcHero;
   

   public NPSHeroController(ViewNPCHiro viewNpcHero, NPCHeroModel npcHeroModel)
   {
      _npcHeroModel = npcHeroModel;
      _viewNpcHero = viewNpcHero;
   }

   public void Init()
   {
      _viewNpcHero.СollisionNPCEvt += CollisionHandler;
      _viewNpcHero.DestroyEvt += Dispose;
      _viewNpcHero.MoveingEvt += MovementNPC;
   }
   
   private void MovementNPC()
   {
      _viewNpcHero.transform.DOMove(new Vector3(Random.Range(-_npcHeroModel.RadiusMove, _npcHeroModel.RadiusMove),
         0.3f, Random.Range(-_npcHeroModel.RadiusMove, _npcHeroModel.RadiusMove)), Random.Range(1, 5)).OnComplete(MovementNPC);
   }

   public  void Execute(float deltaTime)
   {
     
   }

   private void Dispose()
   {
      InitializationGame.Execute -= Execute;
      _viewNpcHero.СollisionNPCEvt -= CollisionHandler;
      _viewNpcHero.DestroyEvt -= Dispose;
      _viewNpcHero.MoveingEvt -= MovementNPC;

   }

   private void CollisionHandler(string name)
   {Debug.Log($" NPC Столкнулись с {name}");
   }
}
