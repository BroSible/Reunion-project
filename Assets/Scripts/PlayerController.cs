using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        moveDirection *= speed;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
