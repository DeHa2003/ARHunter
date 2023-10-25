using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationMainScene : MonoBehaviour
{
    [SerializeField] private List<AnimationMenuActivate> activates;
    private Coroutine coroutine;

    private bool isChangingActivePanel = true;
    private void OnEnable()
    {
        OnTargetEvents.onTargetFound += PlayAnimations;
        OnTargetEvents.onTargetLost += ReturnAnimations;
    }

    private void OnDisable()
    {
        OnTargetEvents.onTargetFound -= PlayAnimations;
        OnTargetEvents.onTargetLost -= ReturnAnimations;
    }
    private IEnumerator ActivatesAnimations(bool isOpening)
    {
        if (isOpening && isChangingActivePanel)
        {
            Debug.Log("Activate");
            for (int i = 0; i < activates.Count; i++)
            {
                activates[i].StartAnimation();
                yield return new WaitForSeconds(activates[i].GetTimeToPlayNextAnimation());
            }
            isChangingActivePanel = false;
        }
        else if (!isOpening && !isChangingActivePanel)
        {
            Debug.Log("Diactivate");
            for (int i = activates.Count - 1; i >= 0; i--)
            {
                activates[i].ReturnAnimation();
                yield return new WaitForSeconds(activates[i].GetTimeToPlayNextAnimation());
            }
            isChangingActivePanel = true;
        }
        coroutine = null;
    }
    public void PlayAnimations(bool isOpening)
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(ActivatesAnimations(isOpening));
        }
    }

    private void PlayAnimations()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(ActivatesAnimations(true));
        }
    }

    private void ReturnAnimations()
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(ActivatesAnimations(false));
        }
    }
}
