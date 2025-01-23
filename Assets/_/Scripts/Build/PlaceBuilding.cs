using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    public void PlacePrefab(GameObject prefab)
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Instantiate(prefab, mousePosition, Quaternion.identity);
    }
}
