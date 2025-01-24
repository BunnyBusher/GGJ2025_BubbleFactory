using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float _gatheringRange;
    [SerializeField] private LayerMask _gatheringMask;

    [SerializeField] private float _delayBeforeGather;
    private float _currentTimer;

    public bool isGathering;

    //private PlaceBuilding _placeBuilding;

    private Camera _camera;

    //test
    //public GameObject _prefabToBuild;
    //[SerializeField] private LayerMask _buildArea;
    //[SerializeField] private LayerMask _nonBuildArea;


    private void Awake()
    {
        //_placeBuilding = GetComponent<PlaceBuilding>();
        _camera = Camera.main;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GatherableChecker();

        }
        else isGathering = false;

        if (Input.GetMouseButtonDown(0))
        {
            // Convertir la position de la souris en un rayon dans l'espace 2D
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                // Vérifie si l'objet touché a le script OnClickAdd
                OnClickAdd onClickAddScript = hit.transform.GetComponent<OnClickAdd>();
                if (onClickAddScript != null)
                {
                    Debug.Log(onClickAddScript.gameObject.name);
                    onClickAddScript.AddRessource();
                }
            }

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
        if (!Physics2D.OverlapCircle(transform.position, _gatheringRange, _gatheringMask))
        {
            return;
        }
            _currentTimer -= Time.deltaTime;
        if (_currentTimer > 0)
        {
            isGathering = true;
            return;
        }
        
            
        
        Collider2D collision = Physics2D.OverlapCircle(transform.position, _gatheringRange, _gatheringMask);
        
            if (collision.TryGetComponent(out iGatherable ressource))
            {
            Vector3 pos = transform.position;    
                ressource.Gather(pos);
                _currentTimer = _delayBeforeGather;
            }
        
    }
}
