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
	private static int AnimatorIsMoving = Animator.StringToHash("IsMoving");
    private static int AnimatorAttackTrigger = Animator.StringToHash("AttackTrigger");
    private static int AnimatorDamagedState = Animator.StringToHash("Damaged");
    private static int AnimatorDeathState = Animator.StringToHash("Death");

    [SerializeField] private float _maximumHealth = 100;
    [SerializeField] private float _enemyHealth = 100;
	[SerializeField] private float _damage = 10;
	[SerializeField] private UnityEvent _onDeath;
	[SerializeField] private UnityEvent _onHealthUpdated;
	[SerializeField] protected Animator _animator;
	[SerializeField] private float attackDisableTime = 1f;
	[SerializeField] private float despawnDelay = 2.4f;

    protected NavMeshAgent navMeshAgent;

    public float MaximumHealth { get => _maximumHealth; }
    public float EnemyHealth { get => _enemyHealth; }
    public float Damage { get => _damage; }
    public bool CanAttack { get; private set; }

    private Coroutine _disabledAttack;

	private bool _isDead = false;
    private void Awake()
    {
        InitializeNavMeshAgent();
		EnableAttack();
    }

    void Update()
    {
		navMeshAgent.destination = CanAttack ? GetTarget("Player") : transform.position;
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (navMeshAgent.velocity.magnitude > 0.01f)
        {
			_animator.SetBool(AnimatorIsMoving, true);
			return;
        }

        _animator.SetBool(AnimatorIsMoving, false);
    }

    public virtual void OnDamageTaken(WeaponBase weapon)
	{
        _animator.Play(AnimatorDamagedState);
        DisableAttack();
        if (EnemyHealth <= 0)
		{
                Die();
		}
	}

    protected virtual void Die()
	{
        StopCoroutine(_disabledAttack);
		CanAttack = false;
        _animator.Play(AnimatorDeathState);
		_onDeath.Invoke();
		GlobalGameManager.Instance.HudManager.AddKillCount();
		this.ActivateWithDelay(DespawnObject, despawnDelay);
	}

    private void DespawnObject()
    {
		gameObject.SetActive(false);
    }

    public void onAttack()
	{
		_animator.SetTrigger(AnimatorAttackTrigger);
	}

	public virtual void OnAttackSuccess()
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

	private void DisableAttack()
	{
        if (_disabledAttack != null)
        {
            StopCoroutine( _disabledAttack );
        }
        CanAttack = false;
		_disabledAttack = this.ActivateWithDelay(EnableAttack, attackDisableTime);
	}

    private void EnableAttack()
    {
        CanAttack = true;

    }
}