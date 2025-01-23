using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    //Number of Inventory Space
    public List<GameObject> ressourceSlots = new List<GameObject>(10);
    public List<Image> imageSlots = new List<Image>();

    public List<GatherableScriptableObject> currentRessourceData;
    public List<int> currentRessource;

    private void Start()
    {
        currentRessource = new List<int>();
        for (int i = 0; i < currentRessourceData.Count; i++)
        {
            currentRessource.Add(0);
        }
    }

    private void AddCurrentRessource(Pickup ressource)
    {
        for (int i = 0; i < currentRessourceData.Count; ++i)
        {
            if (currentRessourceData[i].ressourceNameTag == ressource.tag)
            {
                currentRessource[i]++;
                break;
            }
        }
    }

    private void RemoveCurrentRessource(Pickup ressource)
    {
        for (int i = 0; i < currentRessourceData.Count; ++i)
        {
            if (currentRessourceData[i].ressourceNameTag == ressource.tag)
            {
                currentRessource[i]--;
                break;
            }
        }
    }
    public void AddRessource (int slotIndex, GameObject pickup)
    {
        ressourceSlots[slotIndex] = pickup;
        Pickup ressource = pickup.GetComponent<Pickup>();
        AddCurrentRessource(ressource);
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
        Pickup ressource = ressourceSlots[slotIndex].GetComponent<Pickup>();
        RemoveCurrentRessource(ressource);

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
