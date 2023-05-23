using System;

public class NPCHeroModel
{
    public Action KillUnit;
    
    public int HP;
    public int SpeedMove;
    public int SpeedRotate;
    public int Damage;
    public int RadiusMove;

    public NPCHeroModel(int hp, int speedMove,int speedRotate, int damage, int radiusMove)
    {
        HP = hp;
        SpeedMove = speedMove;
        SpeedRotate = speedMove;
        Damage = damage;
        RadiusMove = radiusMove;
    }

    public void ChangeHP(int hp)
    {
        HP -= hp;
        if (HP < 1)
        {
            KillUnit?.Invoke();
        }
    }
}
