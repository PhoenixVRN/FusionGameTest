using System;
using UnityEngine;

public class PlayerBuilder
{
    private MovementController _movementController;
    private InputController _inputController;
    private CollisionController _collisionController;
    
    private HeroModel _model;

    public PlayerBuilder()
    {
        var hero = Resources.Load("Unit/Hero", typeof(GameObject)) as GameObject;

        var heroObj = GameObject.Instantiate(hero,
            UtilMVP.GetRandomSpawnPoint(), Quaternion.identity);
        heroObj.transform.SetParent(Reference.ActiveElements);

        var builder = heroObj.GetComponent<BuilderCfg>();
        _model = new HeroModel(builder.UnitDataCfg.HitPoint,
            builder.UnitDataCfg.SpeedMove,
            builder.UnitDataCfg.SpeedRotate,
            builder.UnitDataCfg.Damage);

        _movementController = new MovementController(heroObj.GetComponent<ViewHero>(), _model);
        _inputController = new InputController(heroObj.GetComponent<ViewHero>(), _model);
        _collisionController = new CollisionController(heroObj.GetComponent<ViewHero>(), _model);

        ListController.ExecuteEvt += ((IExecute) _movementController).Execute;
        ListController.ExecuteEvt += ((IExecute) _inputController).Execute;
        _model.KillUnitEvt += DestroyHero;
    }

    private void DestroyHero()
    {
        ListController.ExecuteEvt -= ((IExecute) _movementController).Execute;
        ListController.ExecuteEvt -= ((IExecute) _inputController).Execute;
        _model.KillUnitEvt -= DestroyHero;
        
        if (_movementController is IDisposable disposable)
        {
            disposable.Dispose();
        }

        _inputController.Dispose();
        _collisionController.Dispose();
    }
}