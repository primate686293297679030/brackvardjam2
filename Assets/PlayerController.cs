using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 4f;
        [SerializeField] private float jumpSpeed = 300f;
        public Camera mainCamera;
        public BoxCollider2D jumpBox;
        public GunScriptableObject weapon; 
        public LayerMask groundMask;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _move;
        private bool _jump;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (jumpBox.IsTouchingLayers(groundMask))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _jump = true;
                }
            }
        }

        private void FixedUpdate()
        {
            var position = _rigidbody2D.position;
            mainCamera.transform.position = new Vector3(position.x, position.y, -10);
            
            _rigidbody2D.velocity = new Vector2(_move.x * movementSpeed, _rigidbody2D.velocity.y);
            if (_jump)
            {
                _jump = false;
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
            }
        }
    }
}