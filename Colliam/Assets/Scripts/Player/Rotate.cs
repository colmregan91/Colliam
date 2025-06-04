using UnityEngine;

public class Rotate : MonoBehaviour
{
    private InputManager _inputManager;
    public Vector3 lookDirection = Vector3.zero;
    [SerializeField] private Camera cam;
    void Start()
    {
        _inputManager = GetComponent<InputManager>();
    }
    void Update()
    {
        lookDirection = _inputManager._lookInput;
        RotateTowardMouse();
    }

    void RotateTowardMouse()
    {
        // Use lookInput instead of Input.mousePosition
        Ray ray = Camera.main.ScreenPointToRay(lookDirection);

        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0));

        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 direction = hitPoint - transform.position;
            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 25f);
            }
        }
    }
}
