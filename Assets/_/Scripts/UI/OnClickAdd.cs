using UnityEngine;

public class OnClickAdd : MonoBehaviour
{
    [SerializeField] private  GatherableScriptableObject _ressourceToAdd;
    [SerializeField] private StockInventory _stockInventory;

    

    private void OnMouseDown()
    {
        _stockInventory.AddRessource(_ressourceToAdd.ressourceNameTag);
    }
}
