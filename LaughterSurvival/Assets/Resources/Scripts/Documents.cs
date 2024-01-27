using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Documents : MonoBehaviour
{
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Face the camera
        transform.LookAt(Camera.main.transform);
        transform.Translate(transform.forward*-3);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.LookAt(Camera.main.transform);
        if(timer >= 40f/30f)
        {
            Destroy(this.gameObject);
        }
    }
}
