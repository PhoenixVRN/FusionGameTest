public class NPSHeroController : IExecute
{
   private NPCHeroModel _npcHeroModel;
   private ViewNPCHiro _viewNpcHero;

   public NPSHeroController(NPCHeroModel npcHeroModel, ViewNPCHiro viewNpcHero)
   {
      _npcHeroModel = npcHeroModel;
      _viewNpcHero = viewNpcHero;
   }

   public void StartMoveNPC()
   {
      _viewNpcHero._radiusMove = _npcHeroModel.RadiusMove;
      _viewNpcHero.MovementNPC();
   }

   public void Execute(float deltaTime)
   {
      
   }
}
