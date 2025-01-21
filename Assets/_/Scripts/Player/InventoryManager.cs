using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Number of Inventory Space
    public List<GameObject> ressourceSlots = new List<GameObject>(10);
    public List<Image> imageSlots = new List<Image>();


    public void AddRessource (int slotIndex, GameObject pickup)
    {
        ressourceSlots[slotIndex] = pickup;
        Pickup ressource = pickup.GetComponent<Pickup>();
        imageSlots[slotIndex].sprite = ressource.ressourceIcon;
    }

    public int GetFirstEmptyIndex()
    {

        for (int i = 0; i < ressourceSlots.Count; i++)
        {
            if (ressourceSlots[i] == null)
            {
                return i; 
            }
        }
        return -1;
    }

    public void RemoveRessource (int slotIndex)
    {
        if (ressourceSlots[slotIndex] == null) return;
        var drop = Instantiate(ressourceSlots[slotIndex].gameObject,transform.position, Quaternion.identity);
        Pickup dropPickup = drop.GetComponent<Pickup>();
        dropPickup.isPicked = true;
        drop.SetActive(true);
        ressourceSlots [slotIndex] = null;
        imageSlots [slotIndex].sprite = null;
    }
}
