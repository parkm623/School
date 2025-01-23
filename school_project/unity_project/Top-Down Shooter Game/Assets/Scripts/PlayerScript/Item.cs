using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public List<GameObject> items;
    public Transform spawnPoint;
    public string type;
    public bool hasSpawned = false;

    void Update()
    {
        if (!hasSpawned && GameManager.Instance.CheckClear())  
        {
            Spawn();
            hasSpawned = true;  
        }
        if (!GameManager.Instance.CheckClear())
        {
            hasSpawned = false;
        }
    }
    private void Spawn()
    {
        if (items.Count == 0 || spawnPoint == null)
        {
            return;
        }

        int randomIndex = Random.Range(0, items.Count);
        Instantiate(items[randomIndex], spawnPoint.position, Quaternion.identity);

    }
}
