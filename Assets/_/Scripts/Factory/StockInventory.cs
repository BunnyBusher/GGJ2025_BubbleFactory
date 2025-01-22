using System.Collections.Generic;
using UnityEngine;

public class StockInventory : MonoBehaviour
{
    [System.Serializable]
    public class Stock
    {
        [SerializeField] private string _stockName;
        public GatherableScriptableObject ressourceData;
        public int maxNumberOfRessource;
        public int currentNumberOfRessource;
    }

    [SerializeField] private List<Stock> _stock;
    private PlayerStats _player;

    private void Start()
    {
        _player = FindAnyObjectByType<PlayerStats>();
    }

    

   

    public int NumberOfRessourceInStock(string tag)
    {
        for (int i = 0; i < _stock.Count; i++)
        {
            if (_stock[i].ressourceData.ressourceNameTag == tag)
            {
                Debug.Log(tag + " _stock[i].currentNumberOfRessource");
                return _stock[i].currentNumberOfRessource;
            }
        }

        return -1;
    } 
}
