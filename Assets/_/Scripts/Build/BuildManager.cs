using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public List<BuildFactoryScriptableObject> factoryBuildSlots = new List<BuildFactoryScriptableObject>(5);
    public List<Image> imageSlots = new List<Image>();

    //reference
    private InventoryManager _inventory;

    //variable
    public int numberNeededToProduce;

    private void Awake()
    {
        _inventory = FindFirstObjectByType<InventoryManager>();
    }

    private void Start()
    {
        for (int i = 0;i < factoryBuildSlots.Count; i++)
        {
            if (factoryBuildSlots[i] == null) break;
            imageSlots[i].sprite = factoryBuildSlots[i].sprite;            
        }   
    }

    public void CheckRessourceForBuild()
    {
        //if (factoryBuildSlots[0].)


    }

    //public virtual void AddRessource(string tag)
    //{
    //    for (int i = 0; i < _inventory.ressourceSlots.Count; i++)
    //    {
    //        if (_inventory.ressourceSlots[i] != null && _inventory.ressourceSlots[i].CompareTag(tag))        //If find a ressource with the same tag in Inventory
    //        {
    //            Destroy(_inventory.ressourceSlots[i]);//Remove that ressource from inventory
    //            _inventory.RemoveRessource(i);
    //            for (int stockIndex = 0; stockIndex < _stock.Count; stockIndex++)
    //            {
    //                if (_stock[stockIndex].ressourceData.ressourceNameTag == tag
    //                    && _stock[stockIndex].currentNumberOfRessource < _stock[stockIndex].maxNumberOfRessource) // Find the ressource in stock, and check if not at Max Stock
    //                {
    //                    _stock[stockIndex].currentNumberOfRessource++;
    //                    if (_stock[stockIndex].currentNumberOfRessource >= _stock[stockIndex].numberNeededToProduce) _isRessourceInStock[stockIndex] = true;
    //                    return;
    //                }
    //            }
    //            Debug.LogWarning("Ressource remove from inventory, but not add in stock");

    //        }
    //    }

    //}


}
