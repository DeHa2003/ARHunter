using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTargetEvents : MonoBehaviour
{
    public static Action onTargetFound;
    public static Action onTargetLost;

    public void OnTargetFound()
    {
        onTargetFound?.Invoke();
    }

    public void OnTargetLost()
    {
        onTargetLost?.Invoke();
    }
}
