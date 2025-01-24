using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class ShowUiWhenPlayerNear : MonoBehaviour
{
    private List<GameObject> _childrenGameObject;

    private void OnEnable()
    {
        _childrenGameObject = new List<GameObject>();
        _childrenGameObject.Clear();

        
        foreach (Transform child in transform)
        {
                _childrenGameObject.Add(child.gameObject);
                
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < _childrenGameObject.Count; i++)
            {
                _childrenGameObject[i].SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < _childrenGameObject.Count; i++)
            {
                _childrenGameObject[i].SetActive(false);
            }
        }
    }
}
