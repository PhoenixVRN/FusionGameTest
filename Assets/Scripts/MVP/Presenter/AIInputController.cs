using System;
using UnityEngine;

public class AIInputController : IExecute, IDisposable
{
    private ViewHero _viewHero;
    private HeroModel _modelHero;
    
    private Vector3 _target = Vector3.zero;
    private Vector3 _direction;

    public AIInputController(ViewHero viewHero, HeroModel modelHero)
    {
        _viewHero = viewHero;
        _modelHero = modelHero;
        _target = UtilMVP.GetRandomSpawnPoint();
    }

    public void Execute(float deltaTime)
    {
        InputAI(deltaTime);
    }

    private void InputAI (float deltaTime)
    {
        if (Vector3.Distance(_viewHero.transform.position, _target) < 1f)
        {
            _target = UtilMVP.GetRandomSpawnPoint();
            _modelHero.Target = _target;
        }
        else
        {
           _direction = (_target - _viewHero.transform.position).normalized;
           _modelHero.Move = _viewHero.transform.position + _direction * deltaTime * _modelHero.SpeedMove;
        }
    }
    public void Dispose()
    {
        
    }
}
