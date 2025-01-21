using UnityEngine;

public class DropAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        Vector2 drop = CalculateDropPosition();
        if (drop == Vector2.zero) drop = CalculateDropPosition();
        transform.localPosition = drop;
    }

    private Vector2 CalculateDropPosition()
    {
        Vector2 dropPosition = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        return dropPosition;
    }
}
