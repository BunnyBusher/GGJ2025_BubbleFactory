using PrimeTween;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    
    [SerializeField]
    private float _pullSpeed;
    private Transform _pickupTransform;
    private bool _isDelaying = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (_inventory.GetFirstEmptyIndex() == -1) return;
        if (collision.TryGetComponent(out iCollectible colletile))
        {
            Pickup pickup = collision.GetComponent<Pickup>();
            if (pickup.isPicked) return;
            _pickupTransform = collision.GetComponent<Transform>();                        
            Tween.Custom(collision.transform.position, transform.position, duration: _pullSpeed, onValueChange: MagnetRessource).OnComplete(() =>
            {
            colletile.Collect();
            });
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.activeInHierarchy) return;
        if (collision.TryGetComponent(out iCollectible colletile))
        {
            if (_isDelaying) return;
            Pickup pickup = collision.GetComponent<Pickup>();
            _isDelaying = true;
            Tween.Delay(2f).OnComplete(() =>
            {
                pickup.isPicked = false;
                _isDelaying = false;
            });
        }
    }
    private void MagnetRessource (Vector3 move)
    {
        _pickupTransform.position= move;

    }
}
