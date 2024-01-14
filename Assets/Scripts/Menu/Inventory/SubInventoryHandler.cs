using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubInventoryHandler : MonoBehaviour
{
   public string specification;
    public InventoryItemSO[] inventoryItemSO;
    public GameObject[] inventoryPanelsOO; // the same as inventoryPanels.gameObject
    public InventoryTemplate[] inventoryPanels;
    public Button[] mySelectBtns;
    InventoryHandler inventoryHandler;
   // Start is called before the first frame update
    void OnEnable()
    {
        inventoryHandler = GameObject.FindWithTag("Inventory").GetComponent<InventoryHandler>();
        inventoryHandler.showPanel(inventoryItemSO, inventoryPanelsOO ,inventoryPanels, specification);
    }

    public void select(int btnNr){
        inventoryHandler.select(btnNr,specification, inventoryPanelsOO);
    }
}
