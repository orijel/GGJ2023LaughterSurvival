using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
	private Camera myCamera;

	private void OnEnable()
	{
		if (myCamera != null)
		{
			return;
		}

		myCamera = Camera.main;
	}

	private void Update()
	{
		transform.LookAt(transform.position + myCamera.transform.rotation * Vector3.forward,
			myCamera.transform.rotation * Vector3.up);
	}
}