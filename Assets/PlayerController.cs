using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 2f;
        [SerializeField] private float jumpSpeed = 2f;
        public LayerMask groundMask;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _move;
        private bool jump = false;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (_rigidbody2D.IsTouchingLayers(groundMask))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                    Debug.Log("Jump: " + jump);
                }
            }
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = new Vector2(_move.x * movementSpeed, _rigidbody2D.velocity.y);
            if (jump)
            {
                jump = false;
                _rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
            }
        }
    }
}