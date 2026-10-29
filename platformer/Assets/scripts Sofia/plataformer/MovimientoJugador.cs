using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    public GroundCheck groundCheck;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float movimientoX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movimientoX = 0f;

        if (Keyboard.current == null) return;

        if (Keyboard.current.aKey.isPressed)
        {
            movimientoX = -1f;
            spriteRenderer.flipX = true;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            movimientoX = 1f;
            spriteRenderer.flipX = false;
        }

        if (Keyboard.current.wKey.wasPressedThisFrame
            && groundCheck != null && groundCheck.isGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,fuerzaSalto);
            
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimientoX * velocidad,rb.linearVelocity.y );
       
    }
}