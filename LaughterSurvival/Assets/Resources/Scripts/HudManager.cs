using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemiesLeftText;
    private int _enemiesLeft;
    [SerializeField] TextMeshProUGUI killCount;
    private int _killCount = 0;
    [SerializeField] List<Spawner> spawners;
    
    // Start is called before the first frame update
    void Start()
    {
        _enemiesLeft = spawners.Select(x => x.objectPool.poolSize).Sum();
        enemiesLeftText.text = "Enemies Left: " + _enemiesLeft.ToString();
        killCount.text = "Kill Count: " + _killCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //totalEnemiesText.text 
    }

    public void AddKillCount() //call onDie of enemies
    {
        _enemiesLeft--;
        _killCount++;
        enemiesLeftText.text = "Enemies Left: " + _enemiesLeft.ToString();
        killCount.text = "Kill Count: " + _killCount.ToString();
    }
}
 