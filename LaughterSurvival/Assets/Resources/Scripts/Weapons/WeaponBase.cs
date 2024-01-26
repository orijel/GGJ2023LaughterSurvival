using Assets.Resources.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string _weaponId;
    [SerializeField] private float _damage;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private UnityEvent _onAttack;

    [Header("References")]
    [SerializeField] private Collider _Collider;
    [SerializeField] private GameObject _mainGameObject;

    public string WeaponId { get => _weaponId; }

    private void Start()
    {
        _Collider.enabled = false;
    }

    public void Activate()
    {
        _mainGameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _mainGameObject.SetActive(false);
        DeactivateTrigger();
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
