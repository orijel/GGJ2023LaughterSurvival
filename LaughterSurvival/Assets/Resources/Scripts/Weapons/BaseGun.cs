using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseGun : WeaponBase
{
	[SerializeField] private ObjectPool _myProjectilePool;
	// [SerializeField] private float _projectileSpeed = 5f;
	// [SerializeField] private ForceMode _forceMode;
	// private LayerMask groundMask;
	// [SerializeField] private float groundOffset = 1;

	public void ShootProjectile()
	{
		for (int i = 0; i < _myProjectilePool.pool.Length; i++)
		{
			if (_myProjectilePool.pool[i].activeInHierarchy == false)
			{
				HandlePoolSettings(i);
				SetTransformOrigins(i);
				_myProjectilePool.pool[i].SetActive(true);

				return;
			}
		}
	}

	private void SetTransformOrigins(int i)
	{
		_myProjectilePool.pool[i].transform.position = transform.position;
		_myProjectilePool.pool[i].transform.rotation = transform.rotation;
		_myProjectilePool.pool[i].transform.parent = null;
	}

	private void HandlePoolSettings(int i)
	{
		ProjectileBase mybase = _myProjectilePool.pool[i].GetComponent<ProjectileBase>();
		mybase.myPool = _myProjectilePool;
		mybase.myWeapon = this;
	}
}