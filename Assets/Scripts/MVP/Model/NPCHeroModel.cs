public class NPCHeroModel
{
    public int HP = 10;
    public int SpeedMove = 200;
    public int SpeedRotate = 100;
    public int Damage = 2;
    public int RadiusMove;

    public NPCHeroModel(int hp, int speedMove,int speedRotate, int damage, int radiusMove)
    {
        HP = hp;
        SpeedMove = speedMove;
        SpeedRotate = speedMove;
        Damage = damage;
        RadiusMove = radiusMove;
    }
}
