using UnityEngine;
using UnityEngine.Events;

public class PowerUpCuracion : MonoBehaviour
{
    [SerializeField] private UnityEvent _alCurar;

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.GetComponentInParent<MovimientoJugador>() == null)
        {
            return;
        }

        Debug.Log("Corazon recogido");
        _alCurar.Invoke();
        Destroy(gameObject);
    }
}
