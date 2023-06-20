using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    [SerializeField] private bool _isGrounded;
    public float _jumpHeight= 5f;

    
    private Rigidbody2D _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
        float _horizontalInput = Input.GetAxis("Horizontal");
        if (_horizontalInput != 0)
        {
            _animator.SetBool("Running", true);
            if (_horizontalInput > 0)
            {
                transform.Translate(Vector2.right * _speed * Time.deltaTime);
                transform.localScale = new Vector2(1.5f, 1.5f);
            }
            if (_horizontalInput < 0)
            {
                transform.Translate(Vector2.left * _speed * Time.deltaTime);
                transform.localScale = new Vector2(-1.5f,1.5f);
            }
        }
        else
        {
            _animator.SetBool("Running", false);
        }

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _animator.SetTrigger("Jumping");
        }
    }

    public void OnJump() 
    {
        _rb.AddForce(new Vector2(0f, _jumpHeight), ForceMode2D.Impulse);
    }
}
