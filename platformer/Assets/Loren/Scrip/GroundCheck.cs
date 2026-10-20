using UnityEngine;

  public class GroundCheck : MonoBehaviour
{
    public bool isGround;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGround = true;
        Debug.Log("Tocó el suelo");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
        Debug.Log("Estoy saltando");
    }
}