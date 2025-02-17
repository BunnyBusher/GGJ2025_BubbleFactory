using PrimeTween;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private InventoryManager _inventory;

    private void Start()
    {
        _inventory = GetComponent<InventoryManager>();
    }

    public void GatherRessource(GameObject ressource)
    {
        int emptySlot = _inventory.GetFirstEmptyIndex();
        if (emptySlot == -1) return; // if no space left in inventory, do nothing
       
        _inventory.AddRessource(emptySlot, ressource);
        ressource.SetActive(false);
        
        
        
    }
}
