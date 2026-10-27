using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;          // velocidad automática hacia la derecha
    public float multiplicadorDerecha = 1.5f; // más rápido si presionas →
    public float multiplicadorIzquierda = 1f; // velocidad al ir hacia la izquierda con ←

    [Header("Salto")]
    public float fuerzaSalto = 10f;

    private Rigidbody2D rb;
    private float movimientoX;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Por defecto el jugador avanza solo hacia la derecha
        movimientoX = 1f;

        if (Keyboard.current == null) return;

        // Flecha izquierda: retrocede
        if (Keyboard.current.leftArrowKey.isPressed)
            movimientoX = -multiplicadorIzquierda;

        // Flecha derecha: avanza más rápido
        else if (Keyboard.current.rightArrowKey.isPressed)
            movimientoX = multiplicadorDerecha;

        // Salto con ESPACIO (solo si está tocando el suelo)
        if (Keyboard.current.spaceKey.wasPressedThisFrame && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);

        // Se reinicia cada paso de física; OnCollisionStay2D lo vuelve a activar
        enSuelo = false;
    }

    // Detecta si estamos pisando algo (normal apuntando hacia arriba)
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