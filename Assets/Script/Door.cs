using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    private BoxCollider2D _collider;
    private Animator _animator;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        _animator.SetBool("IsOpened", true);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if (other.GetComponent<Animator>().GetBool("Enter"))
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _animator.SetBool("IsOpened", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        
    }

}
