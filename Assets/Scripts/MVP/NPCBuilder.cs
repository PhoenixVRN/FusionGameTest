using Unity.VisualScripting;
using UnityEngine;

public class NPCBuilder
{
    public  NPCBuilder()
    {
        var npc = Resources.Load("Unit/NPCHero", typeof(GameObject)) as GameObject;
        NPSHeroController npsHeroController = new NPSHeroController(GameObject.Instantiate(npc,
                UtilMVP.GetRandomSpawnPoint(), Quaternion.identity).GetComponent<ViewNPCHiro>(),
            UnitData(npc.GameObject()));
        npsHeroController.Init();
        InitializationGame.Execute += ((IExecute) npsHeroController).Execute;
    }
    
    private NPCHeroModel UnitData(GameObject prefab)
    {
        var builder = prefab.GetComponent<BuilderCfg>();
        return new NPCHeroModel(builder.UnitDataCfg.HitPoint, builder.UnitDataCfg.SpeedMove,
            builder.UnitDataCfg.SpeedRotate,
            builder.UnitDataCfg.Damage, builder.UnitDataCfg.RadiusMove);
    }
}
