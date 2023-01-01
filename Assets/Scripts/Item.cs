using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Properties")]
    public int itemScore;
    public string description;

    private ItemPlacer itemPlacer;
    public  Transform mySpawnPoint ;
    

    void Awake()
    {
        itemPlacer = FindObjectOfType<ItemPlacer>();
    }

    void Update()
    {
        
    }




    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        if (othercollider.CompareTag("Player"))
        {
            Debug.Log("Item picked up by the player!");
            itemPlacer.ObjectTaken(mySpawnPoint);
            Destroy(this.gameObject);
        }
    }
}
