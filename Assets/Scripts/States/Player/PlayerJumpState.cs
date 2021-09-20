using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerController playerController) : base(playerController)
    {
        playerController.PlayJumpAnim();
    }

    public override void Update(PlayerController playerController)
    {
        playerController.playerMovement.JumpPlayer();
        playerController.playerMovement.MovePlayer();
    }

    public override void FixedUpdate(PlayerController playerController)
    {
    }

    public override void OnCollisionEnter(PlayerController playerController, Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerController.playerMovement.canJump = true;
            playerController.currentState = new PlayerIdleState(playerController);
        }
    }

    public override void OnCollisionExit(PlayerController playerController, Collision2D collision)
    {
    }

    public override void OnTriggerEnter(PlayerController playerController, Collider2D collision)
    {
    }

    public override void OnTriggerExit(PlayerController playerController, Collider2D collision)
    {
    }
}