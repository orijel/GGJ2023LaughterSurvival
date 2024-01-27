using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private List<String> gameNames;
	[SerializeField] private TextMeshProUGUI title;

	private string GetRandomName()
	{
		return gameNames[Random.Range(0, gameNames.Count - 1)];
	}
	

	private void Start()
	{
		title.text = GetRandomName();
		InvokeRepeating("SwitchTitle", 3, 3);
		title.gameObject.transform.DOScale(1.1f, 0.5f).SetEase(Ease.InOutBounce).SetLoops(-1, LoopType.Yoyo);
	}
	

	public void LoadLevel(int idx)
	{
		SceneManager.LoadScene(idx);
	}

	public void Quit()
	{
		Application.Quit();
	}

	// private IEnumerator SwitchTitle()
	// {
	// 	yield return title.text = GetRandomName();
	// }

	private void SwitchTitle()
	{
		title.text = GetRandomName();
	}
}