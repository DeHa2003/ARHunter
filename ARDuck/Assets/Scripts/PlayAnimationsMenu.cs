using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationMenuActivate
{
    [SerializeField] private Animator animator;
    [SerializeField] private string nameTriggerPlay;
    [SerializeField] private string nameTriggerReturn;
    [SerializeField] private float timeToPlayNext;

    public void StartAnimation()
    {
        animator.SetTrigger(nameTriggerPlay);
    }

    public void ReturnAnimation()
    {
        animator.SetTrigger(nameTriggerReturn);
    }
    public float GetTimeToPlayNextAnimation()
    {
        return timeToPlayNext;
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}

public class PlayAnimationsMenu : MonoBehaviour
{
    [SerializeField] private List<AnimationMenuActivate> activates;
    [SerializeField] private List<AnimationMenuActivate> diactivates;

    public bool isDoneDollyCart = false;
    private bool isPlaying;

    public static float timeToActivate = 7;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(timeToActivate);
        StartCoroutine(ActivatesAnimations(true));
        timeToActivate = 0;
    }
    public IEnumerator ActivatesAnimations(bool isOpening)
    {
        isPlaying = true;

        if (isOpening)
        {

            if (isDoneDollyCart)
            {
                StartCoroutine(DiactivateAnimations(false));
            }

            for (int i = 0; i < activates.Count; i++)
            {
                activates[i].StartAnimation();
                yield return new WaitForSeconds(activates[i].GetTimeToPlayNextAnimation());
            }
        }
        else if(!isOpening)
        {
            for (int i = activates.Count-1; i >= 0; i--)
            {
                activates[i].ReturnAnimation();
                yield return new WaitForSeconds(activates[i].GetTimeToPlayNextAnimation());
            }

            if (isDoneDollyCart)
            {
                StartCoroutine(DiactivateAnimations(true));
            }

        }
        isPlaying = false;
    }

    public IEnumerator DiactivateAnimations(bool isOpening)
    {
        if (isOpening)
        {

            for (int i = 0; i < diactivates.Count; i++)
            {
                diactivates[i].StartAnimation();
                yield return new WaitForSeconds(diactivates[i].GetTimeToPlayNextAnimation());
            }
        }
        else if (!isOpening)
        {
            for (int i = diactivates.Count - 1; i >= 0; i--)
            {
                diactivates[i].ReturnAnimation();
                yield return new WaitForSeconds(diactivates[i].GetTimeToPlayNextAnimation());
            }
        }
        isDoneDollyCart = false;
    }

    public void PlayAnimation(bool isOpening)
    {
        if(!isPlaying)
        StartCoroutine(ActivatesAnimations(isOpening));
    }

    public void CheckPressButton()
    {
        isDoneDollyCart = true;
    }
}
