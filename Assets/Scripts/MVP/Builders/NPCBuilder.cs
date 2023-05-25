using System;
using UnityEngine;

public class NPCBuilder
{
    private MovementAIController _movementAIController;
    private AIInputController _aiInputController;
    private CollisionController _collisionController;
    private HeroModel _model;
    public  NPCBuilder()
    {
        var hero = Resources.Load("Unit/NPCHero", typeof(GameObject)) as GameObject;
        
        var heroObj = GameObject.Instantiate(hero,
            UtilMVP.GetRandomSpawnPoint(), Quaternion.identity);
        heroObj.transform.SetParent(Reference.ActiveElements);
        
        var builder = heroObj.GetComponent<BuilderCfg>();
        _model = new HeroModel(builder.UnitDataCfg.HitPoint, builder.UnitDataCfg.SpeedMove,
            builder.UnitDataCfg.SpeedRotate,
            builder.UnitDataCfg.Damage);
        _movementAIController = new MovementAIController(heroObj.GetComponent<ViewHero>(), _model);
        _aiInputController = new AIInputController(heroObj.GetComponent<ViewHero>(), _model);
        _collisionController = new CollisionController(heroObj.GetComponent<ViewHero>(), _model);
        
         ListController.ExecuteEvt += ((IExecute) _movementAIController).Execute;
         ListController.ExecuteEvt += ((IExecute) _aiInputController).Execute;
         _model.KillUnitEvt += DestroyHero;
    }
    
    private void DestroyHero()
    {
        ListController.ExecuteEvt -= ((IExecute) _movementAIController).Execute;
        ListController.ExecuteEvt -= ((IExecute) _aiInputController).Execute;
        _model.KillUnitEvt -= DestroyHero;
        
        if (_movementAIController is IDisposable disposable)
        {
            disposable.Dispose();
        }

        _aiInputController.Dispose();
        _collisionController.Dispose();
    }
}
