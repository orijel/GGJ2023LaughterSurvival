using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Interactble> _interactbles = new List<Interactble>();

    private void OnTriggerEnter(Collider other)
    {
        Interactble interactable = other.GetComponent<Interactble>();
        if (interactable != null)
        {
            _interactbles.Add(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Interactble interactable = other.GetComponent<Interactble>();
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
