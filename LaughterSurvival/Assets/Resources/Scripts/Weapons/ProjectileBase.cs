using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ProjectileBase : MonoBehaviour
{
	[SerializeField] public WeaponBase myWeapon;
	public ObjectPool myPool;
	private float speed = 5f;
	private float timeStamp;

	private void OnEnable()
	{
		timeStamp = Time.time;
	}


	private void OnTriggerEnter(Collider other)
	{
		//TODO: get enemy base and deal damage
		// if (other.gameObject.CompareTag("Player")) return;
		if (other.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("(Trigger)EMOTIONAL DAMAGE!! :" + other.gameObject.name);
			EnemyBase enemy = other.gameObject.GetComponent<EnemyBase>();
			if (enemy != null)
			{
				enemy.OnDamageTaken(myWeapon);
			}

			ResetProjectile();
		}
	}
	//
	// private void OnCollisionEnter(Collision other)
	// {
	// 	//TODO: get enemy base and deal damage
	// 	if (other.gameObject.CompareTag("Player")) return;
	// 	Debug.Log("EMOTIONAL DAMAGE!! :" + other.gameObject.name);
	// 	Zombie enemy = other.gameObject.GetComponent<Zombie>();
	// 	if (enemy != null)
	// 	{
	// 		enemy.OnDamageTaken(20);
	// 	}
	//
	// 	ResetProjectile();
	// }

	private void Update()
	{
		transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
	}


	private void ResetProjectile()
	{
		gameObject.SetActive(false);
		transform.parent = myPool.transform;
	}
}