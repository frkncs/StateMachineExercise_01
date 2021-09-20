using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    // Public Variables
    [HideInInspector] public PlayerMovement playerMovement;

    [HideInInspector] public PlayerBaseState currentState;

    // Private Variables
    private Animator _animator;

    private const float _maxPlayerYScale = 1;
    private const float _minPlayerYScale = .5f;

    #endregion Variables

    private void Start()
    {
        InitializeVariables();
    }

    private void Update()
    {
        UpdateCurrentState();

        currentState.Update(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }

    public void EnLargePlayer()
    {
        Vector3 _playerLocalScale = transform.localScale;

        if (_playerLocalScale.y < _maxPlayerYScale)
        {
            _playerLocalScale = new Vector3(_playerLocalScale.x, _playerLocalScale.y + .5f, 1);
            transform.localScale = _playerLocalScale;
        }
    }
    public void MinimizePlayer()
    {
        Vector3 _playerLocalScale = transform.localScale;

        if (_playerLocalScale.y > _minPlayerYScale)
        {
            _playerLocalScale = new Vector3(_playerLocalScale.x, _playerLocalScale.y - .5f, 1);
            transform.localScale = _playerLocalScale;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
    }

    public void PlayRunAnim()
    {
        _animator.SetBool("running", true);
    }

    public void PlayIdleAnim()
    {
        _animator.SetBool("running", false);
        _animator.SetBool("jump", false);
    }

    public void PlayJumpAnim()
    {
        _animator.SetBool("jump", true);
    }

    private void InitializeVariables()
    {
        _animator = GetComponent<Animator>();
        currentState = new PlayerIdleState(this);
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void UpdateCurrentState()
    {
        if (playerMovement.canJump) // Player on ground
        {
            if (CheckUserDownButtons())
            {
                if (currentState.GetType() != typeof(PlayerRunState))
                {
                    currentState = new PlayerRunState(this);
                }
            }
            else if (CheckUserUpButtons())
            {
                currentState = new PlayerIdleState(this);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentState.GetType() != typeof(PlayerJumpState))
            {
                currentState = new PlayerJumpState(this);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (transform.localScale.y < _maxPlayerYScale)
            {
                EnLargePlayer();
            }
            else
            {
                MinimizePlayer();
            }
        }
    }

    private bool CheckUserDownButtons()
    {
        return Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
    }

    private bool CheckUserUpButtons()
    {
        return Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow);
    }
}