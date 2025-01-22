using PrimeTween;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    
    [SerializeField]
    private float _pullSpeed;
    private Transform _pickupTransform;
    private InventoryManager _inventory;

    private void Awake()
    {
        _inventory = FindFirstObjectByType<InventoryManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_inventory.GetFirstEmptyIndex() == -1) return;
        if (collision.TryGetComponent(out iCollectible colletile))
        {
            Pickup pickup = collision.GetComponent<Pickup>();
            if (pickup.isDropped) return;
            if (pickup.isPicked) return;
            pickup.isPicked = true;

            _pickupTransform = collision.GetComponent<Transform>();                        
            Tween.Custom(collision.transform.position, transform.position, duration: _pullSpeed, onValueChange: MagnetRessource).OnComplete(() =>
            {
                
                pickup.isPicked = false;
            });
        }
    }
    
    private void MagnetRessource (Vector3 move)
    {
        _pickupTransform.position= move;

    }
}
