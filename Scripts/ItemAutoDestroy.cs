using UnityEngine;

public class ItemAutoDestroy : MonoBehaviour
{
    public Transform player;
    public float radius = 10f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > radius)
        {
            Destroy(gameObject);
        }
    }
}
    