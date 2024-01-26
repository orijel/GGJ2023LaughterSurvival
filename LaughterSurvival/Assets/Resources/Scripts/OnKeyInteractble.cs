using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class OnKeyInteractble : Interactble
{
    [SerializeField] public UnityEvent onCollision;
    [SerializeField] public KeyCode onKey;
    
    private bool _inCollision = false;

    public Collider colliderToAdd  = new BoxCollider();

    void Awake()
    {
        // Check if the GameObject doesn't have a collider attached
        if (GetComponent<Collider>() == null)
        {
            // Instantiate and add the desired collider component
            BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            // You might want to set the properties of the collider here (size, etc.) if needed

            Debug.Log("Collider added!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {  
        _inCollision = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _inCollision = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_inCollision && Input.GetKeyDown(onKey))
        {
            Renderer renderer = GetComponentInChildren<Renderer>();
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            renderer.material.color = randomColor;
            onCollision.Invoke();
        }
    }
}
