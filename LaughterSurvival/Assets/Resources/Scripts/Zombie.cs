using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : EnemyBase
{
    [SerializeField] private int startHealth = 100;
    [SerializeField] public int Damaage = 100;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = InitializeNavMeshAgent();
    }
    private void OnEnable()
    {
        SetHealth(startHealth);
    }

    void Update()
    {
        navMeshAgent.destination = GetTarget("Player");
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

    protected override void Die()
    {
        gameObject.SetActive(false);
    }
}
