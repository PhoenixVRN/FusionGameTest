using System;
using UnityEngine;

public class BulletModel 
{
    public Action KillUnitEvt;
    public Action СollisionModelEvt;
    
    public int HP = 10;
    public int SpeedMove = 200;
    public int SpeedRotate = 100;
    public int Damage = 2;

    public Vector3 Move = new Vector3();
    public Vector3 Rotate = new Vector3();



    public BulletModel(int hp, int speedMove,int speedRotate, int damage)
    {
        HP = hp;
        SpeedMove = speedMove;
        SpeedRotate = speedMove;
        Damage = damage;
    }
    public void ChangeHP(int hp)
    {
        HP -= hp;
        if (HP < 1)
        {
            KillUnitEvt?.Invoke();
        }
    }
}
