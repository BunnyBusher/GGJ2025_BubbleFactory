using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Number of Inventory Space
    public List<Pickup> ressourceSlots = new List<Pickup>(10);


    public void AddRessource (int slotIndex, Pickup pickup)
    {
        ressourceSlots[slotIndex] = pickup;
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
}
