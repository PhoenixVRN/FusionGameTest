using Unity.VisualScripting;
using UnityEngine;

public class PlayerBuilder
{
   public  PlayerBuilder()
   {
      var player = Resources.Load("Unit/Hero", typeof(GameObject)) as GameObject;
      PlayerController playerController = new PlayerController(GameObject.Instantiate(player,
         UtilMVP.GetRandomSpawnPoint(), Quaternion.identity).GetComponent<ViewPlayer>(),
         UnitData(player.GameObject()));
      playerController.Init();
      InitializationGame.Execute += ((IExecute) playerController).Execute;
   }
   
   private HeroModel UnitData(GameObject prefab)
   {
      var builder = prefab.GetComponent<BuilderCfg>();
      return new HeroModel(builder.UnitDataCfg.HitPoint, builder.UnitDataCfg.SpeedMove,
         builder.UnitDataCfg.SpeedRotate,
         builder.UnitDataCfg.Damage);
   }
}
