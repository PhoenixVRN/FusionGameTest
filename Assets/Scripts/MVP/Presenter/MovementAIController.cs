using System;
using UnityEngine;

public class MovementAIController : IExecute, IDisposable
{
    private ViewHero _viewHero;
    private HeroModel _modelHero;
    
    public MovementAIController (ViewHero viewHero, HeroModel modelHero)
    {
        _viewHero = viewHero;
        _modelHero = modelHero;
    }
    public void Execute(float deltaTime)
    {
        _viewHero.Rb.velocity = _modelHero.Move;
        _viewHero.transform.Rotate(_modelHero.Rotate);
    }
    public void Dispose()
    {
    }
}
