using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 1;
    private Vector2 _movement;
    private bool facingRight = true;
    private float counter = 0f;
    public float jumpForce;
    private bool atacking = false;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxcollider;
    
    private bool shouldJump;
    private bool canJump;
    private float downTimeRight;

private int jumpAir=0;

    void Awake()
    {
        rigidbody=transform.GetComponent<Rigidbody2D>();
        boxcollider=transform.GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if(canJump && Input.GetKeyDown(KeyCode.Space))
        {
            downTimeRight = Time.time;
            Debug.Log("HIII "+ (Time.time - downTimeRight));
            
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            if (Time.time - downTimeRight > 3){
                 canJump=true;
                 shouldJump=true;
             }
             else{
                canJump = false;
                shouldJump = true;
             }
        }
        if (!atacking)
        {
            _movement = new Vector2(horizontalInput, 0f);
        }

        if (horizontalInput < 0f && facingRight)
        {
            flip();
        }
        else if (horizontalInput > 0f && !facingRight)
        {
            flip();
        }

        if (_movement == Vector2.zero && !atacking)
        {
            counter += 1 * Time.deltaTime;
        }
        else
        {
            counter = 0f;
        }
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = _movement.normalized.x * speed;
        rigidbody.velocity = new Vector2(horizontalVelocity, rigidbody.velocity.y);
        if(shouldJump) {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            shouldJump = false;
        }
    }
    

    private void flip()
    {
        facingRight = !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX *= -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
       canJump = true;
       
       Debug.Log("objHit: " + col.transform.name);
    }
}
