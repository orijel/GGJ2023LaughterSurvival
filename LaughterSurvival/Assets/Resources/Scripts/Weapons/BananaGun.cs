using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaGun : WeaponBase
{
    private static int ShootAnimatorHash = Animator.StringToHash("Shoot");

    [SerializeField] private float _attackTick = 0.3f;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _vfx;

    private IList<EnemyBase> _enemeiesInRange = new List<EnemyBase>();
    private Coroutine _attackCoroutine;

    public void Shoot()
    {
        _animator.SetTrigger(ShootAnimatorHash);
        _attackCoroutine = this.ActivateWithDelay(TryDamageEnemy, _attackTick);
    }

    public void StopVfx()
    {
        _vfx.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    public void CancelAttack()
    {
        StopCoroutine(_attackCoroutine);
    }

    public void DamageEnemyByCollider(Collider other)
    {
        EnemyBase enemyBase = other.GetComponent<EnemyBase>();
        if (enemyBase == null)
        {
            return;
        }
        _enemeiesInRange.Add(enemyBase);
    }

    public void RemoveEnemyFromCollider(Collider other)
    {
        EnemyBase enemyBase = other.GetComponent<EnemyBase>();
        if (enemyBase == null)
        {
            return;
        }
        _enemeiesInRange.Remove(enemyBase);
    }

    private void TryDamageEnemy()
    {
        Debug.Log("damaging enemy");
        foreach (var enemy in _enemeiesInRange)
        {
            Debug.Log("actually damaging enemy");
            HitEnemey(enemy);
        }
        _attackCoroutine = this.ActivateWithDelay(TryDamageEnemy, _attackTick);
    }
}
