using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Item : MonoBehaviour, Interactuable
{
    [SerializeField] private ItemSO myData;
    [SerializeField] private GameManagerSO gameManager;
    public void Interact()
    {
        gameManager.InventorySystem.AddItem(myData);
        Destroy(this.gameObject);
    }
}
