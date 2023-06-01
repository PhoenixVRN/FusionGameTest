using System;
using UnityEngine;

public class BuilderController : BaseController
{
    protected GameObject _gameEntity;

    public BuilderController SetPosition(Vector3 position)
    {
        if (_gameEntity != null)
        {
            _gameEntity.transform.position = position;
        }
        return this;
    }
    
    public BuilderController SetRotation(Vector3 rotaion)
    {
        if (_gameEntity != null)
        {
            _gameEntity.transform.rotation = Quaternion.Euler(rotaion);
        }
        return this;
    }
}
public class BulletBuilder : BuilderController
{
    private CollisionController _collisionController;
    private MovementInputBulletController _movementInputBulletController;
    private MovementController _movementController;
    private HeroModel _model;



    public  BulletBuilder()
    {
        var hero = Resources.Load("Unit/Bullet", typeof(GameObject)) as GameObject;
        
        _gameEntity = GameObject.Instantiate(hero, Reference.ActiveElements);

        var builder = _gameEntity.GetComponent<BuilderCfg>();
        _model = new HeroModel(builder.UnitDataCfg.HitPoint, builder.UnitDataCfg.SpeedMove,
            builder.UnitDataCfg.SpeedRotate,
            builder.UnitDataCfg.Damage);
        _movementInputBulletController = new MovementInputBulletController(_gameEntity.GetComponent<ViewHero>(), _model);
        _movementController = new MovementController(_gameEntity.GetComponent<ViewHero>(), _model);
        _collisionController = new CollisionController(_gameEntity.GetComponent<ViewHero>(), _model);
        
        AddController(_movementInputBulletController);
        AddController(_movementController);
        AddController(_movementInputBulletController);
       
        _model.KillUnitEvt += DestroyHero;
    }
    
    private void DestroyHero()
    {
        Debug.Log("Kill in Bulder");
        ListController.ExecuteEvt -= ((IExecute) _movementController).Execute;
        ListController.ExecuteEvt -= ((IExecute) _movementInputBulletController).Execute;
        _model.KillUnitEvt -= DestroyHero;
        
        if (_movementController is IDisposable disposable)
        {
            disposable.Dispose();
        }

        _movementInputBulletController.Dispose();
        _collisionController.Dispose();
    }
}
