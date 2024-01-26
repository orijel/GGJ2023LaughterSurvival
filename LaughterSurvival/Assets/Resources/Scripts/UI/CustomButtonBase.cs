using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class CustomButtonBase :
	MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
	public virtual void OnPointerEnter(PointerEventData eventData)
	{
	}

	public virtual void OnPointerClick(PointerEventData eventData)
	{
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
	}
}