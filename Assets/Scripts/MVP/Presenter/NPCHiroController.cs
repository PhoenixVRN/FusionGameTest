using UnityEngine;

public class NPSHeroController : ControllerBasic , IExecute
{
   private NPCHeroModel _npcHeroModel;
   private ViewNPCHiro _viewNpcHero;

   public NPSHeroController(NPCHeroModel npcHeroModel, ViewNPCHiro viewNpcHero)
   {
      _npcHeroModel = npcHeroModel;
      _viewNpcHero = viewNpcHero;
      // Init();
   }

   public void StartMoveNPC()
   {
      _viewNpcHero._radiusMove = _npcHeroModel.RadiusMove;
      _viewNpcHero.MovementNPC();
   }

   public  void Execute(float deltaTime)
   {
      Debug.Log("Execute NPC");
   }

   public void Dispose()
   {
      InitializationGame.Execute -= Execute;
     
   }
}
