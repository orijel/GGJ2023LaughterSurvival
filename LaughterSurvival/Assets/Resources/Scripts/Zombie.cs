using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : EnemyBase
{
    [SerializeField] private int startHealth = 100;
    [SerializeField] public int Damaage = 100;
    [SerializeField] private GameObject documents;

    private void OnEnable()
    {
        _animator.applyRootMotion = false;
        SetHealth(startHealth);
    }

    public override void OnDamageTaken(WeaponBase weapon)
    {
        switch (weapon)
        {
            case FartGun:
            case BaseGun:
                SetHealth(EnemyHealth - weapon.Damage);
                base.OnDamageTaken(weapon);
                break;
            default:
                break;
        }
    }

    public override void OnAttackSuccess()
    {
        //Play animation
        GameObject documentInstance = Instantiate(documents, transform.GetChild(0).transform);
        //documentInstance.transform.LookAt(Vector3.up);
        //documentInstance.transform.position += documentInstance.transform.forward;

    }

    public void UpdateAnimatorOnDeath()
    {
        _animator.applyRootMotion = true;
    }
}
