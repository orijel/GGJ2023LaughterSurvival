using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<Transform> transforms;
    [SerializeField] public ObjectPool objectPool;
    [SerializeField] private float interval = 3;

    private System.Random _random = new System.Random();
    private float _timer = 0;
    private int _spawnCounter = 0;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        // Accumulate time
        _timer += Time.fixedDeltaTime;

        // Check if 10 seconds have passed
        if (_spawnCounter < objectPool.pool.Length && _timer >= interval)
        {
            _spawnCounter++;
            // Reset the timer
            _timer = 0;
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
