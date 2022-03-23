using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private float _moveSpeed = 5f;
    private bool _faceRight = true;

    private const string VectorX = "VectorX";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_direction.x * _moveSpeed, _rigidbody.velocity.y);

        if (_faceRight == true && _direction.x < 0)
        {
            Flip();
        }
        else if (_faceRight == false && _direction.x > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _faceRight = !_faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
