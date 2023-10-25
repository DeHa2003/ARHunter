using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private Transform aimObj;

    private Vector3 defaultScale;

    private void Awake()
    {
        defaultScale = aimObj.localScale;
    }

    private void OnEnable()
    {
        Shot.onShot += IncreaseAim;
    }

    private void OnDisable()
    {
        Shot.onShot -= IncreaseAim;
    }
    private IEnumerator Increase()
    {
        var random = Random.Range(1.1f, 2f);

        while (aimObj.localScale.x < random)
        {
            aimObj.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }

        yield return new WaitForSeconds(0.01f);

        while (aimObj.localScale.x > defaultScale.x)
        {
            aimObj.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void IncreaseAim()
    {
        StartCoroutine(Increase());
    }
}
