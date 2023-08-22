using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 2f;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _movementDirection;
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _movementDirection = new Vector2(Input.GetAxis("Horizontal"), -_rigidbody2D.mass);
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = _movementDirection * movementSpeed;
        }
    }
}