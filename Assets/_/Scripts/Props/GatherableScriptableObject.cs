using UnityEngine;

[CreateAssetMenu(fileName ="GatherableScriptableObject", menuName = "ScriptableObjects/Gatherable")]
public class GatherableScriptableObject : ScriptableObject
{
    //Base Prefab for ressource
    [SerializeField] GameObject _prefab;
    public GameObject prefab { get => _prefab; private set => _prefab = value; }

    //Base Stats for ressource
    [SerializeField] float _maxHealth;
    public float maxHealth { get => _maxHealth; private set => _maxHealth = value; }

    //Sprite for ressource in Inventory
    [SerializeField] string _ressourceNameTag;
    public string ressourceNameTag { get => _ressourceNameTag; private set => _ressourceNameTag = value; }
}
