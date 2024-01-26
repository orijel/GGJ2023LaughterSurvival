using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class BanterPopup : MonoBehaviour
{
	[SerializeField] private Transform banterPosition;
	[SerializeField] private TextMeshProUGUI banterTMP;
	[SerializeField] private float banterOffsetY = 10f;
	[SerializeField] private float banterDuration = 3f;
	private float originalScale = 1f;
	float timeStamp;


	[Space(40f)]
	[Header("A List of Rare insults")]
	[SerializeField] private List<string> insults;

	private Camera myCamera;

	private Tween playTween;
	
	private void OnEnable()
	{
		playTween = banterTMP.gameObject.transform.DOScale(1.1f, .3f).SetEase(Ease.InOutBounce)
			.SetLoops(-1, LoopType.Yoyo);
		
		myCamera = Camera.main;
		banterTMP.text = GetRandomInsult();
		playTween.Play();
	}
	
	private void OnCollisionEnter(Collision other)
	{
		if (!other.gameObject.CompareTag("Player"))
		{	//TODO:
				//play effect
					// delay?
					// vfx/ tween
					// sound
			//return to pool
		}
	}

	private void Update()
	{
		//TODO:
			//reveal slowly
		
		TranslateWorldPos();
	}

	private void TranslateWorldPos()
	{
		Vector3 screenPos = myCamera.WorldToScreenPoint(transform.position);
		banterTMP.gameObject.transform.position = new Vector2(screenPos.x, screenPos.y + banterOffsetY);
	}

	public string GetRandomInsult()
	{
		int index = Random.Range(0, insults.Count);
		return insults[index];
	}

	private void HandleHitTween()
	{
		
	}
}