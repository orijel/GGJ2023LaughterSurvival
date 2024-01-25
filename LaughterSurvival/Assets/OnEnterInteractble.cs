using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnterInteractble : MonoBehaviour
{
    //[SerializeField] public Color collisionColor; // Set the color you want on collision
    [SerializeField] public UnityEvent onCollision;
    private void OnTriggerEnter(Collider other)
    {
        Renderer renderer = GetComponentInChildren<Renderer>();
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        renderer.material.color = randomColor;
        onCollision.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("sdfsdf");
    }

    // Update is called once per frame
    void Update()
    {

    }
}