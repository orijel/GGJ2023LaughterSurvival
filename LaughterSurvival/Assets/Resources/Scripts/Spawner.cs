using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<Transform> transforms;
    [SerializeField] ObjectPool objectPool;
    private System.Random _random = new System.Random();
    private float timer = 0;
    private float interval = 10;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        // Accumulate time
        timer += Time.fixedDeltaTime;

        // Check if 10 seconds have passed
        if (timer >= interval)
        {
            // Reset the timer
            timer = 0;
            // Create an instance of the Random class

            // Generate a random number between 0 (inclusive) and 11 (exclusive)
            int spawnIndex = _random.Next(0, transforms.Count);

            Spawn(spawnIndex);
        }
    }

    void Spawn(int spawnIndex)
    {
        foreach (var obj in objectPool.pool) { 
            if(obj.activeInHierarchy == false)
            {
                obj.SetActive(true);
                obj.transform.position = transforms[spawnIndex].position;
                return;
            }
        }
        //Instantiate(objectPool.pool[0], transforms[spawnIndex]);
    }


}
