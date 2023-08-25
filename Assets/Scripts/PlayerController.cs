using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 4f;
        [SerializeField] private float jumpSpeed = 300f;
        public Camera mainCamera;
        public BoxCollider2D jumpBox;
        public PlayerCollider playerCollider;
        private GunScriptableObject gunScriptableObject;
        private GameObject gunObject;
        public LayerMask groundMask;
        private Rigidbody2D _rigidbody2D;
        private Vector2 _move;
        private bool _jump;
        private bool _canShoot = true;
       // public ParticleSystem muzzle;

       public GameObject muzzle;
       public GameObject muzzlePos;
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector2 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            
            _move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (jumpBox.IsTouchingLayers(groundMask))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _jump = true;
                }
            }

            if (playerCollider.currentObject != null && Input.GetKey(KeyCode.E))
            {
                gunObject = Instantiate(playerCollider.currentObject,
                    new Vector3(_rigidbody2D.position.x, _rigidbody2D.position.y, -5), Quaternion.identity);
                gunObject.transform.parent = gameObject.transform;
                gunObject.GetComponent<Rigidbody2D>().simulated = false;
                gunScriptableObject = gunObject.GetComponent<Gun>().gunScriptableObject;

                muzzlePos = GameObject.Find("GunGuy(Clone)").gameObject.transform.GetChild(0).gameObject;
              var muzzleGuy=  Instantiate(muzzle, muzzlePos.transform.position, Quaternion.identity);
              muzzleGuy.transform.SetParent(muzzlePos.transform.parent);
              muzzle = muzzleGuy;
             
                Destroy(playerCollider.currentObject);
            }

            if (gunObject != null)
            {
                gunObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                if (Input.GetButton("Fire1") && _canShoot)
                {
                    Debug.Log("3232r23r");
                    var bullet = Instantiate(gunScriptableObject.ammoType, muzzlePos.transform.position, gunObject.transform.rotation);
                    var rb = bullet.GetComponent<Rigidbody2D>();
                    rb.velocity = bullet.transform.right * 10f;
                    muzzle.GetComponent<ParticleSystem>().Play();
                    StartCoroutine(ShotCooldown());
                   
                }

                if (Input.GetKey(KeyCode.G))
                {
                    var droppedGun = Instantiate(gunObject, gunObject.transform.position, gunObject.transform.rotation);
                    var rb = droppedGun.GetComponent<Rigidbody2D>();
                    rb.simulated = true;
                    rb.AddForce(dir.normalized * 3 + _rigidbody2D.velocity, ForceMode2D.Impulse);
                    Destroy(gunObject);
                    gunObject = null;
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

        private IEnumerator ShotCooldown()
        {
            _canShoot = false;
            GetComponent<Shake>().start = true;
            yield return new WaitForSeconds(1f / gunScriptableObject.fireRate);
            _canShoot = true;
        }
    }
}