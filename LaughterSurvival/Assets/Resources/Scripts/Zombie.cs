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
        EnemyHealth = startHealth;
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = GetTarget("Player");
    }

    public override void OnDamageTaken(WeaponBase weapon)
    {
        if (weapon is FartGun fartGun) {
            EnemyHealth -= fartGun.Damage;
        }

        if (weapon is BaseGun baseGun)
        {
            EnemyHealth -= baseGun.Damage;
        }
        base.OnDamageTaken(weapon);
    }

    protected override void Die()
    {
        gameObject.SetActive(false);
    }
}
