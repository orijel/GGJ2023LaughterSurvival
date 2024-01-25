using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] private GameObject pauseMenuCanvas;
	private bool _isPaused;

	private void Start()
	{
		pauseMenuCanvas.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			TogglePause();
		}
	}

	private void TogglePause()
	{
		_isPaused = !_isPaused;
		if (_isPaused)
		{
			Time.timeScale = 0;
			pauseMenuCanvas.SetActive(true);
		}

		if (!_isPaused)
		{
			Time.timeScale = 1;
			pauseMenuCanvas.SetActive(false);
		}
	}
}