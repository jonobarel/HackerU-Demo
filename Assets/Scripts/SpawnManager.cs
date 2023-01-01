using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField]
    Item[] itemPrefabs; //Prefabs of items to instantiate

    [SerializeField]
    int startingPoolSize;
    
    [SerializeField]
    private List<Item> itemPool;

    [SerializeField]
    GameObject itemsParent;

    void Awake()
    {
        itemPool = new List<Item>();

        RefillPool();

    }

    private void RefillPool()
    {
        for (int i = 0; i < startingPoolSize; i++)
        {
            int prefabIndex = Random.Range(0, itemPrefabs.Length);
            Item newItem = Instantiate(itemPrefabs[prefabIndex], transform);
            newItem.gameObject.SetActive(false);
            itemPool.Add(newItem);
        }
    }
    public Item GetItemFromPool()
    {
        Item item = itemPool[0];
        itemPool.Remove(item);
        if (itemPool.Count == 0)
        {
            RefillPool();
        }
        return item;
    }
}
