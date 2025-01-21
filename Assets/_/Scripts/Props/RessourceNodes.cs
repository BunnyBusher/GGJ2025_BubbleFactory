using UnityEngine;

public class RessourceNodes : MonoBehaviour, iGatherable
{
    [SerializeField] private GatherableScriptableObject _ressourceStats;

    //Current Stats of the ressources
    private float _currentMaxHealth;
    private float _currentHealth;

    private void Start()
    {
        _currentMaxHealth = _ressourceStats.maxHealth;
        CalculateHealth();
    }

    public void CalculateHealth()
    {
        _currentHealth = _currentMaxHealth;
    }

    public void Gather()
    {
        if (_currentHealth <= 0)
        {
            GameObject ressource = Instantiate(_ressourceStats.prefab, transform);
            ressource.transform.localPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _currentHealth = _currentMaxHealth;
        }
        else
        {
            _currentHealth--;
            Debug.Log(this + " " + _currentHealth);
        }
    }
}
