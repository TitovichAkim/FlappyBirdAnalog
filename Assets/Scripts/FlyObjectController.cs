using UnityEngine;

public class FlyObjectController : MonoBehaviour
{
    public float jumpForce = 10f; // Сила подбрасывания
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;
    }
}