using System.Collections;
using PrimeTween;
using UnityEngine;

public class Pickup : MonoBehaviour, iCollectible
{
    public bool isPicked = false;
    public bool isDropped = false;
    public Sprite ressourceIcon;
    private InventoryManager _inventory;

    private void Awake()
    {
        _inventory = FindFirstObjectByType<InventoryManager>();
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { 
        if (_inventory.GetFirstEmptyIndex() == -1) return;
        if (isDropped) return;
        Collect();
        }
    }

    public void Collect()
    {
        PlayerStats player = _inventory.gameObject.GetComponent<PlayerStats>();
        player.GatherRessource(this.gameObject);
    }

    public void TimeBeforeCollectAgain()
    {
        Tween.Delay(3f).OnComplete(() =>
        {
            isDropped = false;
        });

       
    }
}