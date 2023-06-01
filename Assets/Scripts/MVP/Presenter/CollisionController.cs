using System;
using UnityEngine;

public class CollisionController : IDisposable
{
    private ViewHero _viewHero;
    private HeroModel _heroModel;
    
    public CollisionController(ViewHero viewHero, HeroModel heroModel)
    {
        _viewHero = viewHero;
        _heroModel = heroModel;
        _viewHero.СollisionEvt += obj => CollisionHeroHandler(obj);
    }

    private void CollisionHeroHandler(GameObject obj)
    {
        _heroModel.СollisionModelEvt?.Invoke();
        Debug.Log($"Hero столкнулся с {obj}");
    }
    public void Dispose()
    {
        _viewHero.СollisionEvt -= obj => CollisionHeroHandler(obj); 
    }
}
