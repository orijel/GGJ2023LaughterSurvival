using UnityEngine;
using UnityEngine.Events;

public abstract class Interactble : MonoBehaviour
{
    [SerializeField] public UnityEvent onCollision;

    void Awake()
    {
        // Check if the GameObject doesn't have a collider attached
        var collider = GetComponent<Collider>();
        if (collider == null)
        {
            // Instantiate and add the desired collider component
            collider = gameObject.AddComponent<BoxCollider>();
        }
        collider.isTrigger = true;
    }

    public void Invoke()
    {
        onCollision.Invoke();
    }
}
