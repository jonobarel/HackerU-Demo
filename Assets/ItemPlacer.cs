using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemPlacer : MonoBehaviour
{
    
    [SerializeField]
    Transform[] spawnPoints;
    void Start()
    {
        PlaceRandomItem(null);
    }

    private void PlaceRandomItem(Transform exclusion)
    {
        SpawnManager pool = GetComponent<SpawnManager>();

        Item item = pool.GetItemFromPool();

        List<Transform> spawnPointsList = spawnPoints.ToList();

        spawnPointsList.Remove(exclusion);
        
        Transform t = spawnPointsList[Random.Range(0, spawnPointsList.Count)];
        item.transform.position = t.position;
        item.mySpawnPoint = t;
        item.gameObject.SetActive(true);

    }

    public void ObjectTaken(Transform spawnpoint)
    {
        
        PlaceRandomItem(spawnpoint);
    }
}
