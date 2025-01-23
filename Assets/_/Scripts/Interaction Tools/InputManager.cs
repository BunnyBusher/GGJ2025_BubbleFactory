using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float _gatheringRange;
    [SerializeField] private LayerMask _gatheringMask;

    [SerializeField] private float _delayBeforeGather;
    private float _currentTimer;
    private PlaceBuilding _placeBuilding;

    private Camera _camera;

    //test
    public GameObject _prefabToBuild;
    [SerializeField] private LayerMask _buildArea;
    [SerializeField] private LayerMask _nonBuildArea;


    private void Awake()
    {
        _placeBuilding = GetComponent<PlaceBuilding>();
        _camera = Camera.main;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _currentTimer -= Time.deltaTime;
            if (_currentTimer<=0)GatherableChecker();
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosIn2D = _camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosIn2D, Vector2.zero);

            if (hit.collider == null) return;
            if (IsInLayerMask(hit.collider.gameObject, _nonBuildArea)) return;

            if (IsInLayerMask(hit.collider.gameObject, _buildArea))
            {
            _placeBuilding.PlacePrefab(_prefabToBuild);

            }else Debug.Log("Objet " + hit.collider.gameObject.name);
        }

    }

    public bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        // Récupère le layer du GameObject
        int objectLayer = obj.layer;

        // Vérifie si le layer du GameObject est inclus dans le LayerMask
        return ((layerMask.value & (1 << objectLayer)) != 0);
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
