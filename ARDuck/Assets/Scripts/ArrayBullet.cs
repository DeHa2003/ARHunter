using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayBullet : MonoBehaviour
{
    [SerializeField] private List<Transform> transforms;
    [SerializeField] private GameObject prefBullet;

    private List<GameObject> bullets = new List<GameObject>();

    public void AddBullets()
    {
        StartCoroutine(AddBullet());
    }

    private void OnEnable()
    {
        AddBullets();
        Shot.onShot += RemoveBullet;
        Shot.onPerezaryad += AddBullets;
    }

    private void OnDisable()
    {
        Shot.onShot -= RemoveBullet;
        Shot.onPerezaryad -= AddBullets;
    }

    public void RemoveBullet()
    {
        if(bullets.Count > 0)
        {
            GameObject obj = bullets[^1];
            BulletComponents(obj);
        }
    }

    private void BulletComponents(GameObject bullet)
    {
        bullets.Remove(bullet);
        bullet.transform.parent = null;

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        AudioSource source = bullet.GetComponent<AudioSource>();
        rb.isKinematic = false;
        rb.AddForce(transform.forward * 100);
        source.Play();

        Destroy(bullet, 2);
    }

    private IEnumerator AddBullet()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < transforms.Count; i++)
        {
            if (transforms[i].childCount == 0)
            {
                GameObject obj = Instantiate(prefBullet, transforms[i].position, transforms[i].rotation);
                obj.transform.parent = transforms[i];
                bullets.Add(obj);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public int GetCountBullets()
    {
        return bullets.Count;
    }

    public int GetMaxCountBullets()
    {
        return transforms.Count;
    }
}
