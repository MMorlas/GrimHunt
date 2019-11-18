using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTemporalUpgrade : MonoBehaviour
{

    public GameObject[] prefabs;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Spawn()
    {
        Vector3 spawnPos = transform.position;
        GameObject selectedPrefab = prefabs[Random.Range(0, prefabs.Length)];
        GameObject obj = Instantiate(selectedPrefab, spawnPos, Quaternion.Euler(0,0,0));
        obj.name = selectedPrefab.name;
        Destroy(gameObject);


    }
}
