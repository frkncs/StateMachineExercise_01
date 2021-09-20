using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    // Public Variables
    [HideInInspector] public bool canJump = true;

    // Private Variables
    private Rigidbody2D _rb;

    private SpriteRenderer _spriteRenderer;
    private PlayerController _playerController;

    private const float _jumpForce = 500;
    private const float _speed = 6;

    #endregion Variables

    private void Start()
    {
        InitializeVariables();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _playerController.currentState.OnCollisionEnter(_playerController, collision);
    }

    private void InitializeVariables()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerController = GetComponent<PlayerController>();
    }

    public void MovePlayer()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
        {
            _spriteRenderer.flipX = horizontalInput < 0;

            transform.Translate(Vector3.right * (Time.deltaTime * _speed) * horizontalInput);
        }
    }

    public void JumpPlayer()
    {
        if (canJump)
        {
            _rb.AddForce(Vector2.up * (Time.deltaTime * _jumpForce), ForceMode2D.Impulse);

            canJump = false;
        }
    }
}