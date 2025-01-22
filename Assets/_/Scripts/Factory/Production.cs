using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    
    [System.Serializable]
    public class Recipe
    {
        [SerializeField] private string _recipeName;
        public List<Ingredients> ingredient;
    }
    [System.Serializable]
    public class Ingredients
    {
        public GatherableScriptableObject ressourceData;
        public int numberOfIngredient;
    }

    [SerializeField] private Recipe _recipe;

    [Header ("Factory parameters")]
    [SerializeField] private GatherableScriptableObject _product;
    [SerializeField] private int _numberOfProduct;
    [SerializeField] private float _timeToProduct;

    private StockInventory _stock;
    private bool _isRessourceInStock = false;
    private float _currentTime;

    private void Awake()
    {
        _stock = GetComponent<StockInventory>();
    }
    private void Update()
    {
        if (_stock)
        
        _currentTime += Time.deltaTime;
        if (_currentTime > _timeToProduct)
        {
            _currentTime = 0;
            
        }
    }
    private void DoProduction()
    {

    }
}
