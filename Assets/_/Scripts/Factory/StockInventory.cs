using System.Collections.Generic;
using UnityEngine;

public class StockInventory : MonoBehaviour
{
    [System.Serializable]
    public class Stock
    {
        [SerializeField] private string _stockName;
        public GatherableScriptableObject ressourceData;
        public int maxNumberOfRessource;
        public int currentNumberOfRessource;
    }

    [SerializeField] private List<Stock> _stock;
    private InventoryManager _inventory;

    private void Start()
    {
        _inventory = FindAnyObjectByType<InventoryManager>();
    }

    public void AddRessource (string tag)
    {
        for (int i = 0; i < _inventory.ressourceSlots.Count;i++)
        {
            if (_inventory.ressourceSlots[i].tag == tag)        //If find a ressource with the same tag in Inventory
            {
                _inventory.RemoveRessource(i);                  //Remove that ressource from inventory
                for (int stockIndex = 0; stockIndex < _stock.Count; stockIndex++)   
                {
                    if (_stock[stockIndex].ressourceData.ressourceNameTag == tag 
                        && _stock[stockIndex].currentNumberOfRessource < _stock[stockIndex].maxNumberOfRessource) // Find the ressource in stock, and check if not at Max Stock
                    {
                        _stock[stockIndex].currentNumberOfRessource++;
                        return;
                    }
                }
                Debug.LogWarning("Ressource remove from inventory, but not add in stock");
                    
            }
        }
            
    }


}
