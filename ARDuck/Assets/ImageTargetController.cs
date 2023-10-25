using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetController : MonoBehaviour
{
    [SerializeField] private DefaultObserverEventHandler _observer;
    [SerializeField] private GameObject panelFindTarget;

    private void OnEnable()
    {
        Timer.OnFinishTimer += OffImageTracking;
    }

    private void OnDisable()
    {
        Timer.OnFinishTimer -= OffImageTracking;
    }

    private void OffImageTracking()
    {
        _observer.OnTargetLost.Invoke();
        Destroy(panelFindTarget);
        Destroy(gameObject);
    }
}
