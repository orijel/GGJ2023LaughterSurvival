using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] GameObject poolObject;
	[SerializeField] int poolSize;

	public GameObject[] pool;

	void Awake()
	{
		PopulatePool();
	}

	private void PopulatePool()
	{
		pool = new GameObject[poolSize];

		for (int i = 0; i < pool.Length; i++)
		{
			pool[i] = Instantiate(poolObject, transform);
			pool[i].SetActive(false);
		}
	}
}