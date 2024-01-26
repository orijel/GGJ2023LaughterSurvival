using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CustomButtonScale : CustomButtonBase
{
	private const float originalScale = 1f;
	private Tweener enterScale;
	[SerializeField] private float toScale;
	[SerializeField] private float duration;

	public override void OnPointerEnter(PointerEventData eventData)
	{
		enterScale = transform.DOScale(toScale, duration)
			.SetEase(Ease.InOutSine).SetUpdate(true).SetLoops(-1, LoopType.Yoyo);
	}


	public override void OnPointerExit(PointerEventData eventData)
	{
		enterScale.Kill();
		transform.DOScale(originalScale, duration)
			.SetEase(Ease.InOutSine).SetUpdate(true);
	}
}