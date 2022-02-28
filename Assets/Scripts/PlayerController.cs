using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 5;
    public float jumpForce = 2.0f;
    private Vector3 jump;
    private bool isGrounded;
    private bool point1 =false;
     private bool point2=false;
      private bool point3=false;

    private int count;
    public TextMeshProUGUI countText;

    //private float movementZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count=0;
jump = new Vector3(0.0f, 5.0f, 0.0f);
SetCountText();
    }


  void OnCollisionStay(Collision other)
    {
         isGrounded = true;
        if (other.gameObject.CompareTag("FinishPlataform")) 
        {
         print("FINISHED");
        }

          if (other.gameObject.CompareTag("Platform1") && isGrounded && !point1) 
        {
         print("point1");
         point1=true;
         count=count+1;
         SetCountText();
        }else if (other.gameObject.CompareTag("Platform2") && isGrounded && !point2) 
        {
         print("point2");
         point2=true;
           count=count+1;
          SetCountText();
        }else if (other.gameObject.CompareTag("Platform3") && isGrounded && !point3) 
        {
         print("point3");
         point3=true;
          count=count+1;
          SetCountText();
        }

    }
  

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        //Vector3 movementVector = movementValue.Get<Vector3>();

        movementX = movementVector.x;
        movementY = movementVector.y;
        //movementZ = movementVector.z;

    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
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
