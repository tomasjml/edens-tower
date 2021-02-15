using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 1;
    public Animator animator;
    private Vector2 _movement;
    private bool facingRight = true;
    private float counter = 0f;
    private bool atacking = false;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxcollider;
    
    public int jumpForce;
    private bool isGrounded;

    private int veces=0;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

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
        if(Mathf.Abs(horizontalInput)>0){
            animator.SetBool("Run",true);
        }
        else{
            animator.SetBool("Run",false);
        }
        
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded==true &&veces<1){
            rigidbody.velocity=Vector2.up*jumpForce;
            isJumping=true;
            jumpTimeCounter=jumpTime;
            veces++;
            Debug.Log("veces: "+veces);
        }
        if(Input.GetKey(KeyCode.Space)&& isJumping==true && veces==1){
            if(jumpTimeCounter>0){
                rigidbody.velocity=Vector2.up*jumpForce;
                jumpTimeCounter-=Time.deltaTime;
            }
            else{
                isJumping=false;
            }
            
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            isJumping=false;
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
       if (col.collider.gameObject.layer == 9 || col.collider.gameObject.layer==8)
        {
               isGrounded=true;
               veces=0;
        }
        else{
            isGrounded=false;
        }
      // Debug.Log("objHit: " + col.collider.gameObject.layer);
    }
}
