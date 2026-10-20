using UnityEngine;
 
public class MovimientoJugador : MonoBehaviour
{
    [SerializeField] private float _fuerzaSalto = 5f;
    [SerializeField] private float _velocidadmovimiento = 5f;
    [SerializeField] private Rigidbody2D _cuerporigido2D;
    [SerializeField] private DetectorSuelo _detectorSuelo;
 
    private void Awake()
    {
        _cuerporigido2D = GetComponent<Rigidbody2D>();
    }
 
    private void FixedUpdate()
    {
        if (_detectorSuelo.estaEnSuelo)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _cuerporigido2D.AddForce(Vector2.up * _fuerzaSalto, ForceMode2D.Impulse);
 
                Debug.Log("Oprimí la tecla");
            }
        }
 
        _cuerporigido2D.linearVelocity = new Vector2(1* _velocidadmovimiento, _cuerporigido2D.linearVelocity.y);
    }
}