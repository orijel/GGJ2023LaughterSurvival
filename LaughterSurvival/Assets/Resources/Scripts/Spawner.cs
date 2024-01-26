using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<Transform> transforms;
    [SerializeField] GameObject objectTospawn;

    private System.Random _random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Create an instance of the Random class

        // Generate a random number between 0 (inclusive) and 11 (exclusive)
        int spawnIndex = _random.Next(0, transforms.Count);
        Spawn(spawnIndex);
    }

    void Spawn(int spawnIndex)
    {
        Instantiate(objectTospawn, transforms[spawnIndex]);
    }


}
