using System;

public class MovementController: BaseController, IExecute, IDisposable
{
    private ViewHero _viewHero;
    private HeroModel _modelHero;

    public MovementController(ViewHero viewHero, HeroModel modelHero)
    {
        _viewHero = viewHero;
        _modelHero = modelHero;
    }

    public void Execute(float deltaTime)
    {
        MoveHiro();
    }

    public void MoveHiro()
    {
        _viewHero.Rb.velocity = _modelHero.Move;
        _viewHero.transform.Rotate(_modelHero.Rotate);
    }
    
    public void Dispose()
    {
    }
}
