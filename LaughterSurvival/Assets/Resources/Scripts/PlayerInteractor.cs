using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Interactable> _interactbles = new List<Interactable>();

    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            _interactbles.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            _interactbles.Remove(interactable);
        }
    }

    public void Interact()
    {
        foreach (var interactable in _interactbles)
        {
            interactable.Invoke();
        }
    }
}
