using Assets.Resources.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private UnityEvent _onAttack;
    [SerializeField] private Collider _Collider;

    private void Start()
    {
        _Collider.enabled = false;
    }

    public void HitEnemey(EnemyBase enemy)
    {
        enemy.OnHit(this);
    }

    public void Attack()
    {
        _onAttack.Invoke();
    }

    public void ActivateTrigger()
    {
        _Collider.enabled = true;
    }

    public void DeactivateTrigger()
    {
        _Collider.enabled = false;
    }
}
