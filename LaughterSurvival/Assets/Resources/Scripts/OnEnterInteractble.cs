using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnterInteractble : Interactble
{
    //[SerializeField] public Color collisionColor; // Set the color you want on collision
    private void OnTriggerEnter(Collider other)
    {
        Renderer renderer = GetComponentInChildren<Renderer>();
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        renderer.material.color = randomColor;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}