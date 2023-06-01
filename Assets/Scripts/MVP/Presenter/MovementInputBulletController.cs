using System;
using UnityEngine;

public class MovementInputBulletController : BaseController,IExecute, IDisposable
{
    private ViewHero _viewHero;
    private HeroModel _heroModel;
    public MovementInputBulletController (ViewHero viewHero, HeroModel heroModel)
    {
        _viewHero = viewHero;
        _heroModel = heroModel;
        // _heroModel.СollisionModelEvt += Delay;
    }

   
    private void Kill()
    {
        Debug.Log("Kill");
        _heroModel.KillUnitEvt?.Invoke();
    }
   
    public void Execute(float deltaTime)
    {
        InputMoveHiro(_heroModel.SpeedMove, deltaTime);
    }
    
    public void InputMoveHiro(int speed, float deltaTime)
    {
        _heroModel.Move = _viewHero.transform.forward  * speed * deltaTime;
        // _heroModel.Rotate =_viewHero.transform.up * Input.GetAxis("Horizontal") * rotateSpeed * deltaTime;
    }
    public void Dispose()
    {
        _heroModel.СollisionModelEvt -= _heroModel.KillUnitEvt;
    }
}
