using UnityEngine;
using System.Collections;

public class AutoDisappearItem : MonoBehaviour
{
    public float disappearDelay = 2f;

    Transform player;
    bool triggered = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (triggered) return;

        if (player.position.z > transform.position.z)
        {
            triggered = true;
            StartCoroutine(Disappear());
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(disappearDelay);
        Destroy(gameObject);
    }
}
