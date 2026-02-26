using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Cộng 1 điểm
            ScoreManager.instance.AddScore(1);

            // Xóa đồng xu
            Destroy(gameObject);
        }
    }
}
