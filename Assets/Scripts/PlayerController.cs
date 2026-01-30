using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //TODO: Movimiento del jugador
    }

    void Jump()
    {
        // TODO: Salto o acción del jugador
    }

    void Dash()
    {
        //TODO: Dash o acción del jugador
    }

}
