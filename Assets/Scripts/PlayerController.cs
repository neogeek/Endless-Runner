using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private const float _jumpForce = 700.0f;

    private const float _maxHorizontalSpeed = 50f;

    private const float _horizontalSpeedTimeDelta = 100f;

    private const int _maxJumps = 2;

    [SerializeField]
    private SectionSpawner _sectionSpawner;

    [SerializeField]
    private Rigidbody _rigidbody;

    private Transform _mainCameraTransform;

    private float _horizontalSpeed = 10f;

    private bool _isJumpPressed;

    private int _jumpsRemaining = _maxJumps;

    private void Awake()
    {

        _mainCameraTransform = Camera.main.transform;

    }

    private void Update()
    {

        if (_jumpsRemaining > 0 && (Input.GetKeyDown(KeyCode.Space) ||
                                    Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {

            _isJumpPressed = true;

        }

    }

    private void FixedUpdate()
    {

        if (_isJumpPressed)
        {

            _isJumpPressed = false;

            _jumpsRemaining -= 1;

            _rigidbody.AddForce(new Vector2(0, _jumpForce));

        }

        _horizontalSpeed += _horizontalSpeed * (Time.deltaTime / _horizontalSpeedTimeDelta);
        _horizontalSpeed = Mathf.Clamp(_horizontalSpeed, _horizontalSpeed, _maxHorizontalSpeed);

        _rigidbody.velocity = new Vector2(_horizontalSpeed, _rigidbody.velocity.y);

    }

    private void LateUpdate()
    {

        _mainCameraTransform.position = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y + 3.5f,
            _mainCameraTransform.transform.position.z
        );

    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name.Contains("Platform"))
        {

            _jumpsRemaining = _maxJumps;

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.Equals("Mount Trigger"))
        {

            _sectionSpawner.SpawnSection();

        }

        if (other.gameObject.name.Equals("Player Destroy Trigger"))
        {

            SceneManager.LoadScene("Game Over");

        }

    }

}
