using UnityEngine;

public class OnClickAdd : MonoBehaviour
{
    [SerializeField] private  GatherableScriptableObject _ressourceToAdd;
    [SerializeField] private StockInventory _stockInventory;

    
    public void AddRessource()
    {
        _stockInventory.AddRessource(_ressourceToAdd.ressourceNameTag);
    }
   
}
