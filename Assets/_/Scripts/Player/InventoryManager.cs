using System;
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
        
        ressourceSlots [slotIndex] = null;
        imageSlots [slotIndex].sprite = null;
                
    }

    public int AddRessourceToFactory(string tag)
    {
        if (GetFirstEmptyIndex() == -1) return -1;

        for (int i = 0; i < ressourceSlots.Count; i++)
        {
            if (ressourceSlots[i].CompareTag(tag))
            {
                return i;
            }
        }
        return -1;

    }

    public void DropRessource(int slotIndex)
    {
        
        if (ressourceSlots[slotIndex] == null) return;
        Pickup dropPickup = ressourceSlots[slotIndex].GetComponent<Pickup>();
        dropPickup.isDropped = true;
        dropPickup.TimeBeforeCollectAgain();
        ressourceSlots[slotIndex].transform.position = transform.position;
        ressourceSlots[slotIndex].SetActive(true);
        RemoveRessource(slotIndex);
        
    }
}
