using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;
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
            }
            if (_horizontalInput < 0)
            {
                transform.Translate(Vector2.left * _speed * Time.deltaTime);
            }
        }
        else
        {
            _animator.SetBool("Running", false);
        }
    }
}
