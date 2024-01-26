using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAtWorldRotation : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Vector3 _worldRotation;
    [SerializeField] private bool useX_Rotation;
    [SerializeField] private bool useY_Rotation;
    [SerializeField] private bool useZ_Rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gameObjectRotation = _gameObject.transform.rotation.eulerAngles;
        var x = useX_Rotation ? _worldRotation.x : gameObjectRotation.x;
        var y = useY_Rotation ? _worldRotation.y : gameObjectRotation.y;
        var z = useZ_Rotation ? _worldRotation.z : gameObjectRotation.z;
        gameObject.transform.SetPositionAndRotation(gameObject.transform.position, Quaternion.Euler(x, y, z));
    }
}
