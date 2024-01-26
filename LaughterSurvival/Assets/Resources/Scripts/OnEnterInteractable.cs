using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnterInteractable : Interactable
{
    private void OnTriggerEnter(Collider other)
    {
        this.Invoke();
    }
}