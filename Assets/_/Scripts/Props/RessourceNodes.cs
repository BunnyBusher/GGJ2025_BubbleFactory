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
            GameObject ressource = Instantiate(_ressourceStats.prefab);
            
            ressource.transform.position = new Vector2 (transform.position.x + Random.Range(-1f, 1f), transform.position.y + Random.Range(-1f, 1f)) ;
            _currentHealth = _currentMaxHealth;
        }
        else
        {
            _currentHealth--;
            Debug.Log(this + " " + _currentHealth);
        }
    }
}
