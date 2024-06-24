using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject InventoryFrame;
    [SerializeField] private Button[] collectionButtons;
    [SerializeField] private int availableItems = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < collectionButtons.Length; i++) {
            int index = i;
            collectionButtons[i].onClick.AddListener(() => ClickedButton(index));
        }
    }

    private void ClickedButton(int index)
    {
        Debug.Log("Clicked button "+index);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            InventoryFrame.SetActive(!InventoryFrame.activeSelf);
        }
    }

    public void AddItem(ItemSO itemData) {
        collectionButtons[availableItems].gameObject.SetActive(true);
        collectionButtons[availableItems].GetComponent<Image>().sprite = itemData.icon;
        availableItems++;
    }
}
