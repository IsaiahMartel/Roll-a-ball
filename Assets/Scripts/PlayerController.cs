using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 5;
    public float jumpForce = 2.0f;
    private Vector3 jump;
    private bool isGrounded;

    //private float movementZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
jump = new Vector3(0.0f, 5.0f, 0.0f);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        //Vector3 movementVector = movementValue.Get<Vector3>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        //movementZ = movementVector.z;

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
       
    
    }
 void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
        

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }


}
