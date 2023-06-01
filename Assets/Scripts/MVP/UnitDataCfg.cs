using UnityEngine;

[System.Serializable]
public sealed class UnitDataCfg
{
    public int HitPoint => _hp;
    [Header("HitPoint")] [SerializeField] private int _hp = 10;

    public int SpeedMove => _speedMove;
    [Header("SpeedMove")] [SerializeField] private int _speedMove = 50;

    public int SpeedRotate => _speedRotate;
    [SerializeField] private int _speedRotate = 10;

    public int Damage => _damage;
    [Header("Damage")] [SerializeField] private int _damage = 2;
    
}
    
