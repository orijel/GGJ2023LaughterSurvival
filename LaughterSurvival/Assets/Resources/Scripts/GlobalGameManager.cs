using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static GlobalGameManager Instance { get; private set; }
    public PlayerRefrences Player { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        Player = FindObjectOfType<PlayerRefrences>();
    }
}
