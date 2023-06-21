using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _platform;
    private PlatformEffector2D _platformEffector;
    
    public float _jumpHeight= 5f;

    
    private Rigidbody2D _rb;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetButtonDown("Jump") ||Input.GetKeyDown(KeyCode.UpArrow))
        {
            _platformEffector.rotationalOffset = 0;
                _animator.SetTrigger("Jumping");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _platformEffector.rotationalOffset = 180f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _platform = collision.gameObject;
            _platformEffector = _platform.GetComponent<PlatformEffector2D>();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _platform = null;
        }
    }
    public void OnJump() 
    {

        _rb.AddForce(new Vector2(0f, _jumpHeight), ForceMode2D.Impulse);
    }
}
