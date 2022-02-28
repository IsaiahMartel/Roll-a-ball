using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
     private Vector3 correction; 

    // Start is called before the first frame update
    void Start()
    {
        offset =  transform.position - player.transform.position;
       correction = new Vector3(0.0f, -5.0f, 5.0f);
        print(transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset + correction;
        
        
    }
}
