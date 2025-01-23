using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public List<GameObject> ressourceSlots = new List<GameObject>(10);
    public List<Image> imageSlots = new List<Image>();

    //reference
    private InventoryManager _inventory;

    //variable
    public int numberNeededToProduce;


}
