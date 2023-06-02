using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public void ChangeColors1()
    {
         NetworkPlayer.Local.RPC_Change(Color.red);
    }
    public void ChangeColors2()
    {
        NetworkPlayer.Local.RPC_Change(Color.blue);
    }
    public void ChangeColors3()
    {
        NetworkPlayer.Local.RPC_Change(Color.green);
    }
}
