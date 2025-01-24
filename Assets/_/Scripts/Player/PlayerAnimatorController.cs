using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _playerAnimator;
    private PlayerMovement _playerMovement;
    private InputManager _inputManager;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _inputManager = GetComponent<InputManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_inputManager.isGathering) _playerAnimator.SetBool("isMining", true);
        else _playerAnimator.SetBool("isMining", false);

        if (_playerMovement.moveDirection.x != 0 || _playerMovement.moveDirection.y != 0)
        {
            
            _playerAnimator.SetBool("isMoving", true);
            SpriteDirectionChecker();
        }
        else
        {
            _playerAnimator.SetBool("isMoving", false);
        }

    }

    private void SpriteDirectionChecker()
    {
        if (_playerMovement.lastHorizontalVector < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}