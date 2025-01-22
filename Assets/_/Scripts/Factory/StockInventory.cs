using System.Collections.Generic;
using UnityEngine;

public class StockInventory : MonoBehaviour
{
    [System.Serializable]
    public class Stock
    {
        [SerializeField] protected string _stockName;
        public GatherableScriptableObject ressourceData;
        public int maxNumberOfRessource;
        public int currentNumberOfRessource;
        public int numberNeededToProduce;
    }

    [SerializeField] protected List<Stock> _stock;
    protected InventoryManager _inventory;
    public List<bool> _isRessourceInStock;

    private void Start()
    {
        _inventory = FindAnyObjectByType<InventoryManager>();
        _isRessourceInStock = new List<bool>();

        for (int i =0; i < _stock.Count; i++)
        {
            _isRessourceInStock.Add(false);
        }
    }

    public virtual void AddRessource (string tag)
    {
        for (int i = 0; i < _inventory.ressourceSlots.Count;i++)
        {
            if (_inventory.ressourceSlots[i] != null && _inventory.ressourceSlots[i].CompareTag(tag))        //If find a ressource with the same tag in Inventory
            {
                Destroy(_inventory.ressourceSlots[i]);//Remove that ressource from inventory
                _inventory.RemoveRessource(i);
                for (int stockIndex = 0; stockIndex < _stock.Count; stockIndex++)   
                {
                    if (_stock[stockIndex].ressourceData.ressourceNameTag == tag 
                        && _stock[stockIndex].currentNumberOfRessource < _stock[stockIndex].maxNumberOfRessource) // Find the ressource in stock, and check if not at Max Stock
                    {
                        _stock[stockIndex].currentNumberOfRessource++;
                        if (_stock[stockIndex].currentNumberOfRessource >= _stock[stockIndex].numberNeededToProduce) _isRessourceInStock[stockIndex] = true;
                        return;
                    }
                }
                Debug.LogWarning("Ressource remove from inventory, but not add in stock");
                    
            }
        }
            
    }

    public virtual void RemoveRessource(string tag)
    {
        for (int i = 0; i < _stock.Count; i++)
        {
            if (_stock[i].ressourceData.ressourceNameTag == tag 
                && _stock[i].currentNumberOfRessource < 0)
            {
                _stock[i].currentNumberOfRessource--;
                if (_stock[i].currentNumberOfRessource < _stock[i].numberNeededToProduce) _isRessourceInStock[i] = false;
                return;
            }
                        
        }
        Debug.LogWarning("No ressource in stock");
    }


}
