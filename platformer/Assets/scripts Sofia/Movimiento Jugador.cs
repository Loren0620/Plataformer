using UnityEngine;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 20f;

    private Rigidbody2D rb;
    private float movimientoX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimientoX = 0f;

        if (Keyboard.current == null) return;

        if (Keyboard.current.aKey.isPressed)
            movimientoX = -1f;

        if (Keyboard.current.dKey.isPressed)
            movimientoX = 1f;

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,fuerzaSalto);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2( movimientoX * velocidad,rb.linearVelocity.y);
    }
}