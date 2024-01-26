using BLINK.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRefrences : MonoBehaviour
{
    [SerializeField] public TopDownWASDController Controller;
    [SerializeField] public PlayerActions PlayerActions;
    [SerializeField] public WeaponsManager WeaponsManager;
}
