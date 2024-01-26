using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MonoBehaviourUtils
{
    public static Coroutine ActivateWithDelay(this MonoBehaviour obj, Action action, float delayInSeconds)
    {
        return obj.StartCoroutine(ActivateWithDelayImp(action, delayInSeconds));
    }

    public static IEnumerator ActivateWithDelayImp(Action action, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        action();
    }
}
