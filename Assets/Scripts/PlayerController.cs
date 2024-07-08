using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float gravity;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");


            Vector3 forward = new Vector3(1, 0, 1).normalized;  
            Vector3 right = new Vector3(1, 0, -1).normalized;  

            moveDirection = (moveHorizontal * right + moveVertical * forward).normalized;
            moveDirection *= speed;

        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

