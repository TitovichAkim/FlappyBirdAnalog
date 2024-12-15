using UnityEngine;

public class CollisionDetector:MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Column") || collision.gameObject.CompareTag("Ground"))
        {
            FindFirstObjectByType<GameManager>().GameOver(); // Вызываем метод окончания игры
        }
        if(collision.gameObject.CompareTag("Bonus"))
        {
            collision.gameObject.GetComponent<BonusManager>().GetBonus(GetComponent<ScoreCounter>());
        }
        if(collision.gameObject.CompareTag("Portal"))
        {
            collision.gameObject.GetComponent<PortalManager>().ActivatePortal();
        }
    }
}