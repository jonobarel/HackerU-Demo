using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    Transform[] spawnPointPositions;
    [SerializeField]
    Item[] itemPrefabs;

    [SerializeField]
    GameObject itemsParent;

    void Start()
    {

        spawnPointPositions = GetComponentsInChildren<Transform>(); //remember to exclude self

        int i = 0;

        foreach (Transform spawnP in spawnPointPositions)
        {
            if (spawnP.gameObject != gameObject)
            {
                int prefabIndex = Random.Range(0, itemPrefabs.Length);
                Item itemToSpawn = itemPrefabs[prefabIndex];
                Item newItem = Instantiate(itemToSpawn, spawnP.position, Quaternion.identity, itemsParent.transform);
                newItem.name = $"{itemToSpawn.name}_{i}";
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
