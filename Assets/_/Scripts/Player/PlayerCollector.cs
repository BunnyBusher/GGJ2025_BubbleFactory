using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    
    [SerializeField]
    private float _pullSpeed;
    private InventoryManager _inventory;

    private void Start()
    {
        _inventory = GetComponentInParent<InventoryManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_inventory.GetFirstEmptyIndex() == -1) return;
        if (collision.TryGetComponent(out iCollectible colletile))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(forceDirection * _pullSpeed);

            colletile.Collect();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.activeInHierarchy) return;
        if (collision.TryGetComponent(out iCollectible colletile))
        {
            Pickup pickup = collision.GetComponent<Pickup>();
            if (!pickup.isPicked) return;
            else pickup.DelayBeforePickup();
        }
    }
}
