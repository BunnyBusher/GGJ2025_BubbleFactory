using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private InventoryManager _inventory;

    private void Start()
    {
        _inventory = GetComponent<InventoryManager>();
    }

    public void GatherRessource (Pickup ressource)
    {
        int emptySlot = _inventory.GetFirstEmptyIndex();
        if (emptySlot == -1)
        {


        }
        else
        {
            _inventory.AddRessource(emptySlot, ressource);
            ressource.gameObject.SetActive(false);
        }
        
    }
}
