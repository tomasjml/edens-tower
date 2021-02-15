using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Transform farLeft;  // End of screen Left
     public Transform farRight;  //End of Screen Right
    
    public float smoothSpeed=0.125f;

    public Vector3 offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        Vector3 desiredPosition=target.position+offset;
        //desiredPosition.y-=0f;
        Vector3 smooth=Vector3.Lerp(transform.position,desiredPosition,smoothSpeed);
        transform.position = smooth;
        Debug.Log("farRight x: "+farRight.position.x );
        Debug.Log("farLeft x: "+farLeft.position.x);
        Debug.Log ("camara : "+transform.position.x);
        
        if( farRight.position.x-transform.position.x <3){
                 transform.position = new Vector3(farRight.position.x, transform.position.y, transform.position.z);
        }
             }
}
