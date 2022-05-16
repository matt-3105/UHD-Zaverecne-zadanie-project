using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private BoxCollider2D _collider;

    [SerializeField] private AudioSource jumpSoundEffect;
    

    [SerializeField] private LayerMask jumpableGround;
    
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;
    private float _dirX;

    private enum MovementState {idle,run,jump,fall}

    // Start is called before the first frame update
    private void Start(){
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2(_dirX * moveSpeed,_rigidbody.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded()) {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x,jumpForce);
            jumpSoundEffect.Play();
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState state;
        
        if (_dirX > 0f)
        {
            state = MovementState.run;
            _sprite.flipX = false;
        }
        else if (_dirX < 0f)
        {
            state = MovementState.run;
            _sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (_rigidbody.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (_rigidbody.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        _animator.SetInteger("state", (int)state);
    }

    private bool isGrounded() {
        return Physics2D.BoxCast(_collider.bounds.center, _collider.bounds.size, 0f, Vector2.down,.1f,jumpableGround);
    }
    
    
}
