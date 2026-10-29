using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
            Debug.Log("Toco el suelo");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
            Debug.Log("Dejé de tocar el suelo");
        }
    }
}