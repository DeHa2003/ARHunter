using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public int maxCount;
    [SerializeField] private float speedSpawn;
    [SerializeField] List<GameObject> birdList;
    [SerializeField] private GameObject prefBird;
    [SerializeField] private GameObject parentBirds;
    [SerializeField] private List<Transform> posSpawns;

    private bool isSpawned = false;
    private void Awake()
    {
        Spawn();
    }
    private void OnEnable()
    {
        OnTargetEvents.onTargetFound += OnSpawn;
        OnTargetEvents.onTargetLost += OffSpawn;
    }
    private void OnDisable()
    {
        OnTargetEvents.onTargetFound -= OnSpawn;
        OnTargetEvents.onTargetLost -= OffSpawn;
    }

    private void OnSpawn()
    {
        isSpawned = true;
    }

    private void OffSpawn()
    {
        isSpawned = false;
    }
    private void Spawn()
    {
        if (isSpawned)
        {
            if (birdList.Count <= maxCount && isSpawned)
            {
                SpawnBird();
            }
        }

        Invoke(nameof(Spawn), speedSpawn);
    }

    private void SpawnBird()
    {
        GameObject obj = Instantiate(prefBird, parentBirds.transform);
        obj.transform.position = posSpawns[Random.Range(0, posSpawns.Count)].position;
        birdList.Add(obj);
    }

    public void RemoveInList(GameObject obj)
    {
        birdList.Remove(obj);
    }
}
