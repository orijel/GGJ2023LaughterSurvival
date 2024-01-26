using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
	[SerializeField] private Rigidbody myRb;
	private float timeStamp;

	private void OnEnable()
	{
		timeStamp = Time.time;
	}

	private void OnCollisionEnter(Collision other)
	{
		//TODO: get enemy base and deal damage
		if (!other.gameObject.CompareTag("Player"))
		{
			Debug.Log("EMOTIONAL DAMAGE!! :" + other.gameObject.name);
			ResetProjectile();
		}
	}

	// private void FixedUpdate()
	// {
	// 	if (timeStamp + 5f > Time.time)
	// 	{
	// 		ResetProjectile();
	// 	}
	// }

	private void ResetProjectile()
	{
		gameObject.SetActive(false);
		myRb.velocity = Vector3.zero;
	}
}