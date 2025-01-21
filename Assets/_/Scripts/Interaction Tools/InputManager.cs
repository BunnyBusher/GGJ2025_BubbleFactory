using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float _gatheringRange;
    [SerializeField] private LayerMask _gatheringMask;

    [SerializeField] private float _delayBeforeGather;
    private float _currentTimer;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _currentTimer -= Time.deltaTime;
            if (_currentTimer<=0)GatherableChecker();
        }

    }

    private void GatherableChecker()
    {
        if (!Physics2D.OverlapCircle(transform.position, _gatheringRange, _gatheringMask)) return;
        Collider2D collision = Physics2D.OverlapCircle(transform.position, _gatheringRange, _gatheringMask);
        
            if (collision.TryGetComponent(out iGatherable ressource))
            {
                ressource.Gather();
                _currentTimer = _delayBeforeGather;
            }
        
    }
}
