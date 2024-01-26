using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartGun : WeaponBase
{
    private static int ShootAnimatorHash = Animator.StringToHash("Shoot");

    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _vfx;

    public void Shoot()
    {
        _animator.SetTrigger(ShootAnimatorHash);
    }

    public void StopVfx()
    {
        _vfx.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void DamageEnemy(Collider other)
    {
        TryDamageEnemy(other.gameObject);
    }

    private void TryDamageEnemy(GameObject other)
    {
        EnemyBase enemyBase = other.GetComponent<EnemyBase>();
        if (enemyBase == null)
        {
            return;
        }

        HitEnemey(enemyBase);
    }
}
