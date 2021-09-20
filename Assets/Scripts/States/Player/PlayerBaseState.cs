using UnityEngine;

public abstract class PlayerBaseState
{
    public PlayerBaseState(PlayerController playerController)
    {
    }

    public abstract void Update(PlayerController playerController);

    public abstract void FixedUpdate(PlayerController playerController);

    public abstract void OnCollisionEnter(PlayerController playerController, Collision2D collision);

    public abstract void OnCollisionExit(PlayerController playerController, Collision2D collision);

    public abstract void OnTriggerEnter(PlayerController playerController, Collider2D collision);

    public abstract void OnTriggerExit(PlayerController playerController, Collider2D collision);
}