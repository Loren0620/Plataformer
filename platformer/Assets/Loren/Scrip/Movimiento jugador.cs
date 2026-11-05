using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;

    [Header("Salto")]
    public float fuerzaSalto = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float movimientoX;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        movimientoX = 0f;

        if (Keyboard.current == null) return;

        bool izquierda = Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed;
        bool derecha = Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed;

        if (izquierda) movimientoX -= 1f;
        if (derecha) movimientoX += 1f;

        // Flip: mira a la izquierda si va a la izquierda, a la derecha si va a la derecha
        if (sr != null && movimientoX != 0f)
            sr.flipX = movimientoX < 0f;

        bool saltar = Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame;

        if (saltar && enSuelo)
        {
#if UNITY_6000_0_OR_NEWER
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
#else
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
#endif
        }
    }

    void FixedUpdate()
    {
#if UNITY_6000_0_OR_NEWER
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);
#else
        rb.velocity = new Vector2(movimientoX * velocidad, rb.velocity.y);
#endif
        enSuelo = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        foreach (ContactPoint2D punto in col.contacts)
        {
            if (punto.normal.y > 0.5f)
            {
                enSuelo = true;
                return;
            }
        }
    }
}