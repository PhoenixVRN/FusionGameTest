using System;
using UnityEngine;

public class MovementAIController : IExecute, IDisposable
{
    private ViewHero _viewHero;
    private HeroModel _modelHero;

    private Vector3 _target;
    public MovementAIController (ViewHero viewHero, HeroModel modelHero)
    {
        _viewHero = viewHero;
        _modelHero = modelHero;
    }
    public void Execute(float deltaTime)
    {
        if (_target != _modelHero.Target)
        {
            _viewHero.transform.LookAt(_modelHero.Target);
            _target = _modelHero.Target;
        }
        _viewHero.Rb.MovePosition(_modelHero.Move);
    }

    public void Dispose()
    {
    }
}
