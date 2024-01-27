using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBase : MonoBehaviour
{
	[SerializeField] private float _maximumHealth = 100;
    [SerializeField] private float _enemyHealth = 100;
	[SerializeField] private float _damage = 10;
	[SerializeField] private UnityEvent _onDeath;
	[SerializeField] private UnityEvent _onHealthUpdated;

    protected NavMeshAgent navMeshAgent;

    public float MaximumHealth { get => _maximumHealth; }
    public float EnemyHealth { get => _enemyHealth; }
    public float Damage { get => _damage; }

    private void Awake()
    {
        InitializeNavMeshAgent();
    }

    void Update()
    {
        navMeshAgent.destination = GetTarget("Player");
    }

    public virtual void OnDamageTaken(WeaponBase weapon)
	{
		if (EnemyHealth <= 0)
		{
			Die();
		}
	}

	protected virtual void Die()
	{
		_onDeath.Invoke();
	}

	public void onAttack()
	{
	}

	public void onAttackSuccess()
	{
		// TODO: implement this
		//Debug.Log($"Taking damage from: {weapon.name}");
	}

	protected Vector3 GetTarget(string tag)
	{
		GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
		float currentClosestDistance = float.PositiveInfinity;
		GameObject currentClosest = this.gameObject;
		foreach (GameObject target in targets)
		{
			if (Vector3.Distance(this.transform.position, target.transform.position) < currentClosestDistance)
			{
				currentClosest = target;
			}
		}

		return currentClosest.transform.position;
	}

	protected Vector3 GetTarget(Transform target)
	{
		return target.position;
	}

	protected void InitializeNavMeshAgent()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	protected void SetHealth(float health)
	{
		_enemyHealth = health;
		_onHealthUpdated.Invoke();

    }
}