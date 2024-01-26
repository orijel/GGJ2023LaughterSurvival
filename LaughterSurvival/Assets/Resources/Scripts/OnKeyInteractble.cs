using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class OnKeyInteractble : Interactble
{
    [SerializeField] public KeyCode onKey;
    
    private bool _inCollision = false;

    public Collider colliderToAdd  = new BoxCollider();

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
