using Fusion;
using UnityEngine;

public class PhysxBall :NetworkBehaviour
{
    [Networked] private TickTimer life { get; set; }

    public void Init(Vector3 forward)
    {
        life = TickTimer.CreateFromSeconds(Runner, 5.0f);
        GetComponent<Rigidbody>().velocity = forward;
    }

    public override void FixedUpdateNetwork()
    {
        if(life.Expired(Runner))
            Runner.Despawn(Object);
        CheckFalllBall();
    }
    private void CheckFalllBall()
    {
        if (transform.position.y < -12)
        {
            transform.position = Utils.GetRandomSpaenPoint();
        }
    }
}
