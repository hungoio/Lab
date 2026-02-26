using UnityEngine;

public class PlayerAutoRun : MonoBehaviour
{
    public float forwardSpeed = 5f;

    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 move = transform.forward * forwardSpeed;
        controller.Move(move * Time.deltaTime);
    }
}
