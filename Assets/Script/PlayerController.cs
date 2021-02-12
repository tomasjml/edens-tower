using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody2D _body;
    private Animator _animator;

    private Vector2 _movement;
    private bool facingRight = true;
    private float counter = 0;

    private bool atacking = false;

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Door")
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _animator.SetTrigger("Enter");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
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
            counter = 0;
        }
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = _movement.normalized.x * speed;
        _body.velocity = new Vector2(horizontalVelocity, _body.velocity.y);
    }
    private void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
    }

    private void flip()
    {
        facingRight = !facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX *= -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

    }
}
