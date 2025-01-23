using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingFactory", menuName = "ScriptableObjects/Factory")]
public class BuildFactoryScriptableObject : ScriptableObject
{
    [System.Serializable]
    public class FactoryRecipe
    {
            [SerializeField] private string _ressourceName;
            public GatherableScriptableObject ressourceData;
            public int numberNeededToBuild;
        
    }
    //Base Prefab for factory
    [SerializeField] GameObject _prefab;
    public GameObject prefab { get => _prefab; private set => _prefab = value; }

    //Sprite for factory in menu
    [SerializeField] Sprite _sprite;
    public Sprite sprite { get => _sprite; private set => _sprite = value; }

    //Tag for ressource in Inventory
    [SerializeField] List<FactoryRecipe> _factoryRecipes;
    public List<FactoryRecipe> factoryRecipe { get => _factoryRecipes; private set => _factoryRecipes = value; }


}
