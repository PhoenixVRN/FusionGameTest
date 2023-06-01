using System;
using UnityEngine;

public class ShootingController : IExecute, IDisposable
{
    private ViewHero _viewHero;
    private HeroModel _heroModel;
    
    public ShootingController(ViewHero viewHero, HeroModel heroModel)
    {
        _viewHero = viewHero;
        _heroModel = heroModel;
    }

    public void Execute(float deltaTime)
    {
        if (Input.GetMouseButtonDown(0))
        {
            new BulletBuilder().SetPosition(_viewHero.SpawnBullet.position).SetRotation(_viewHero.SpawnBullet.rotation.eulerAngles);
        }
    }
    
    public void Dispose()
    {
        
    }
}
