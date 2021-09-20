using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region Variables

    // Public Variables

    // Private Variables
    private Vector2 diff;
    private Transform playerTrans;

    private const float _speed = 4;

    #endregion Variables

    private void Start()
    {
        InitializeVariables();
    }

    private void Update()
    {
        LookPlayer();
        Move();
    }

    private void InitializeVariables()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LookPlayer()
    {
        diff = playerTrans.transform.position - transform.position;

        transform.up = diff;
    }

    private void Move()
    {
        transform.Translate(Vector2.up * (Time.deltaTime * _speed));
    }
}