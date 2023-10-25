using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    public static Action onShot;
    public static Action onPerezaryad;


    [SerializeField] private Animator animator;
    [SerializeField] ArrayBullet arrayBullet;

    public int bulletCount;
    public void Fire()
    {
        bulletCount = arrayBullet.GetCountBullets();

        if (bulletCount > 0)
        {
            onShot?.Invoke();
            bulletCount -= 1;
        }

        if (bulletCount == 0)
        {
            onPerezaryad?.Invoke();
            animator.SetTrigger("Perezaryad");
            bulletCount = arrayBullet.GetMaxCountBullets(); ;
        }
    }
}
