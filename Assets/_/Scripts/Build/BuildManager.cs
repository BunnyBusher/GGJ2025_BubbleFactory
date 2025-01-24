using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BuildFactoryScriptableObject;

public class BuildManager : MonoBehaviour
{
    public List<BuildFactoryScriptableObject> factoryBuildSlots = new List<BuildFactoryScriptableObject>(5);
    public List<Image> imageSlots = new List<Image>();

    //reference
    private InventoryManager _inventory;
    private List<bool> _isBuildable;
    
      


    private void Awake()
    {
        _inventory = FindFirstObjectByType<InventoryManager>();
    }


    private void Start()
    {
        _isBuildable = new List<bool>();
        for (int i = 0;i < factoryBuildSlots.Count; i++)
        {
            if (factoryBuildSlots[i] == null) break;
            imageSlots[i].sprite = factoryBuildSlots[i].sprite;
            _isBuildable.Add(false);
        }
                
    }
        
    public void CheckRessourceForBuild()
    {
       

    }
     
}
