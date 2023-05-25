using System;
using UnityEngine;

public class InputController : IExecute, IDisposable
{
    private ViewHero _viewHero;
    private HeroModel _heroModel;
    

    public InputController(ViewHero viewHero, HeroModel heroModel)
    {
        _viewHero = viewHero;
        _heroModel = heroModel;
    }
    public void Execute(float deltaTime)
    {
        InputMoveHiro(_heroModel.SpeedMove, _heroModel.SpeedRotate, deltaTime);
    }
    
    public void InputMoveHiro(int speed, int rotateSpeed, float deltaTime)
    {
        _heroModel.Move = _viewHero.transform.forward * Input.GetAxis("Vertical") * speed * deltaTime;
        _heroModel.Rotate =_viewHero.transform.up * Input.GetAxis("Horizontal") * rotateSpeed * deltaTime;
    }
    public void Dispose()
    {
      
    }
}
