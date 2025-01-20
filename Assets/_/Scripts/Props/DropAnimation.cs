using UnityEngine;

public class DropAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        transform.position = new Vector2(Random.Range(0.5f, 1), Random.Range(0.5f, 1));
    }
}
