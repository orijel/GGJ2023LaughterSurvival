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
    [SerializeField] private UnityEvent _onStopAttack;
    [SerializeField] private bool _isContinous = false;
    [SerializeField] private float _attackResetDelay = 1.5f;

    [Header("References")]
    [SerializeField] private Collider _Collider;
    [SerializeField] private GameObject _mainGameObject;

    private bool _isAttacking = false;

    public string WeaponId { get => _weaponId; }
    public bool IsContinous { get => _isContinous; }
    public float AttackResetDelay { get => _attackResetDelay; }

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
        enemy.OnDamageTaken(this);
    }

    public void Attack()
    {
        if (_isAttacking)
        {
            return;
        }

        _isAttacking = true;
        ActivateTrigger();
        _onAttack.Invoke();

        if (IsContinous)
        {
            return;
        }
        this.ActivateWithDelay(ResetAttack, AttackResetDelay);
    }

    public void StopAttack()
    {
        DeactivateTrigger();
        _isAttacking = false;
        _onStopAttack.Invoke();
    }

    public void ActivateTrigger()
    {
        _Collider.enabled = true;
    }

    public void DeactivateTrigger()
    {
        _Collider.enabled = false;
    }

    private void ResetAttack()
    {
        _isAttacking = false;
    }

}
