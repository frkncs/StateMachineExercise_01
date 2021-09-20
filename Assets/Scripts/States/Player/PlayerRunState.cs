using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerController playerController) : base(playerController)
    {
        playerController.PlayRunAnim();
    }

    public override void Update(PlayerController playerController)
    {
        playerController.playerMovement.MovePlayer();
    }

    public override void FixedUpdate(PlayerController playerController)
    {
    }

    public override void OnCollisionEnter(PlayerController playerController, Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerController.GameOver();
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