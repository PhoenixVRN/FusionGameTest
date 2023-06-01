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
        _modelHero.СollisionModelEvt += Rotates;
        Rotates();
        // if (_modelHero != null) _modelHero.СollisionModelEvt += Rotates();
    }
    
    public void Execute(float deltaTime)
    {
        InputAI(deltaTime);
    }

    private void InputAI (float deltaTime)
    {
        if (Vector3.Distance(_viewHero.transform.position, _target) < 1f)
        {
           Rotates();
        }
        else
        {
           // _direction = (_target - _viewHero.transform.position).normalized;
           _modelHero.Move = _viewHero.transform.forward *  deltaTime * _modelHero.SpeedMove;
           _modelHero.Rotate = Vector3.zero;
        }
    }

    private void Rotates()
    {
        _target = UtilMVP.GetRandomSpawnPoint();
        var targetDir = _target - _viewHero.transform.position;
        var rotate = Vector3.SignedAngle(targetDir, _viewHero.transform.forward, Vector3.up);
            
        _modelHero.Rotate = new Vector3(0,rotate,0);
        // Debug.Log(_modelHero.Rotate);
    }
    public void Dispose()
    {
        
    }
}
