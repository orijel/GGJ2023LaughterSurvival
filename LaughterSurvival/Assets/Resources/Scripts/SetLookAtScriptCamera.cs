using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SetLookAtScriptCamera : MonoBehaviour
{
    [SerializeField] private LookAtConstraint constraint;

    // Start is called before the first frame update
    void Start()
    {
        constraint.AddSource(new ConstraintSource() { sourceTransform = GlobalGameManager.Instance.MainCamera.gameObject.transform, weight = 1 });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
