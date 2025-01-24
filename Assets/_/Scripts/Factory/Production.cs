using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Production : StockInventory
{
    
    //[System.Serializable]
    //public class Recipe
    //{
    //    [SerializeField] private string _recipeName;
    //    public List<Ingredients> ingredient;
    //}
    //[System.Serializable]
    //public class Ingredients
    //{
    //    public GatherableScriptableObject ressourceData;
    //    public int numberOfIngredient;
    //}

    //[SerializeField] private Recipe _recipe;

    [Header ("Factory parameters")]
    [SerializeField] private GatherableScriptableObject _product;
    [SerializeField] private int _numberOfProduct;
    [SerializeField] private float _timeToProduct;

    public UnityEvent<int> onScore;

          
    private float _currentTime;

    private void Awake()
    {
        if (onScore == null) onScore = new UnityEvent<int>();
    }


    private void FixedUpdate()
    {
        _currentTime += Time.deltaTime;
        if ( _currentTime >= _timeToProduct)
        {
            DoProduction();
        }

    }


    private void DoProduction()
    {
        foreach (bool b in _isRessourceInStock)
        {
            if (!b)
            {
                return;            
            }
        }
        for (int i =0; i < _stock.Count; i++)
        {
            _stock[i].currentNumberOfRessource -= _stock[i].numberNeededToProduce;
            if (_stock[i].currentNumberOfRessource < _stock[i].numberNeededToProduce)_isRessourceInStock[i] = false;
        }
        _currentTime = 0;
        _ps.Play();
        onScore?.Invoke(_numberOfProduct);
        
    }
}
