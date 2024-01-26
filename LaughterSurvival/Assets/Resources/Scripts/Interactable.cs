using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    [SerializeField] public UnityEvent onCollision;

    void Awake()
    {
        var collider = GetComponent<Collider>();
        collider.isTrigger = true;
    }

    public void Invoke()
    {
        onCollision.Invoke();
    }
}
