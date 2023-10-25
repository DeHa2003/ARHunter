using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RayPlayer : MonoBehaviour
{
    public static Action OnHitBird;

    public int allCountFire;
    public int countGoodFire;
    private void OnEnable()
    {
        Shot.onShot += PlayRaycast;
    }

    private void OnDisable()
    {
        Shot.onShot -= PlayRaycast;
    }
    private void PlayRaycast()
    {
        allCountFire += 1;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.TryGetComponent<Bird>(out var bird))
            {
                countGoodFire += 1;
                bird.DieBird();
                OnHitBird?.Invoke();
            }
        }
    }

    public int GetAllCountFire()
    {
        return allCountFire;
    }

    public int GetCountGoodFire()
    {
        return countGoodFire;
    }
}
