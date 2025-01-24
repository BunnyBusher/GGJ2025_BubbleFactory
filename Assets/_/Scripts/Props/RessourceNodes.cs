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

    public void Gather(Vector3 pos)
    {
        if (_currentHealth <= 0)
        {
            GameObject ressource = Instantiate(_ressourceStats.prefab);
            
            ressource.transform.position = new Vector2 (pos.x + Random.Range(-0.5f, 0.5f), pos.y + Random.Range(-0.5f, 0.5f)) ;
            _currentHealth = _currentMaxHealth;
        }
        else
        {
            _currentHealth--;
            Debug.Log(this + " " + _currentHealth);
        }
    }
}
