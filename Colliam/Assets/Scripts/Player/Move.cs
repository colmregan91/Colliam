using UnityEngine;
using UnityEngine.Serialization;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody _rb;
     public Vector2 _cachedMoveDirection;
    private InputManager _inputManager;
    private Vector3 moveDirection = Vector3.zero;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        _cachedMoveDirection = _inputManager.Moveinput.normalized;
        moveDirection.x = _cachedMoveDirection.x;
        moveDirection.y = 0;
        moveDirection.z = _cachedMoveDirection.y;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }
}