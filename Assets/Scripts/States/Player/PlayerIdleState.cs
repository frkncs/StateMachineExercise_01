using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController playerController) : base(playerController)
    {
        playerController.PlayIdleAnim();
    }

    public override void Update(PlayerController playerController)
    {
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