using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _player;
    private InputManager _inputManager;
    [SerializeField] private float _moveSpeed;
 
    //For Animation Controller
    [HideInInspector] public Vector2 moveDirection;
    [HideInInspector] public float lastHorizontalVector;
    [HideInInspector] public float lastVerticalVector;
    [HideInInspector] public Vector2 lastMovedVector;

    private void Awake()
    {
        _player = GetComponent<Rigidbody2D>();
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        InputManagement();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void InputManagement()
    {
        if (_inputManager.isGathering) return;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveDirection.x != 0 && moveDirection.y == 0)
        {
            lastHorizontalVector = moveDirection.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f);
        }
        if (moveDirection.y != 0 && moveDirection.x == 0)
        {
            lastVerticalVector = moveDirection.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector);
        }
        if (moveDirection.x != 0f && moveDirection.y != 0f)
        {
            lastHorizontalVector = moveDirection.x;
            lastVerticalVector = moveDirection.y;
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }


    }

    private void Move()
    {
       _player.linearVelocity = moveDirection * _moveSpeed;
    }
}
