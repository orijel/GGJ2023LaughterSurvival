using Assets.Resources.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private DamageType _damageType;

    public void HitEnemey(EnemyBase enemy)
    {
        enemy.OnHit(this);
    }
}
