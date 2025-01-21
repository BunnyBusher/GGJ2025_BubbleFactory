using System.Collections;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isPicked = false;
    public Sprite ressourceIcon;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isPicked) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            isPicked=true;
        }
    }

    
}