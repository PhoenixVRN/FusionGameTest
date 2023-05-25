using System;

public class MovementController: IExecute, IDisposable
{
    private ViewHero _viewHero;
    private HeroModel _heroModel;

    public MovementController(ViewHero viewHero, HeroModel heroModel)
    {
        _viewHero = viewHero;
        _heroModel = heroModel;
    }

    public void Execute(float deltaTime)
    {
        MoveHiro();
    }

    public void MoveHiro()
    {
        _viewHero.Rb.velocity = _heroModel.Move;
        _viewHero.transform.Rotate(_heroModel.Rotate);
    }
    
    public void Dispose()
    {
    }
}
