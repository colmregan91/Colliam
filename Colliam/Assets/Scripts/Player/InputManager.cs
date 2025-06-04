using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
        private InputSystem_Actions _inputActions;

        public Vector2 _moveInput;
        public Vector2 _lookInput;

        public Vector2 Moveinput => _moveInput;
        public Vector2 Lookinput => _lookInput;
        private void Awake()
        {
            _inputActions = new InputSystem_Actions();
        }
    
        private void OnEnable()
        {
            _inputActions.Player.Enable();
    
            _inputActions.Player.Move.performed += OnMovePerformed;
            _inputActions.Player.Move.canceled += OnMoveCanceled;
    
            _inputActions.Player.Look.performed += OnLookPerformed;
            _inputActions.Player.Look.canceled += OnLookCanceled;
            
        }
    
        private void OnDisable()
        {
            _inputActions.Player.Move.performed -= OnMovePerformed;
            _inputActions.Player.Move.canceled -= OnMoveCanceled;
    
            // inputActions.Player.Look.performed -= OnLookPerformed;
            // inputActions.Player.Look.canceled -= OnLookCanceled;
            
    
            _inputActions.Player.Disable();
        }
    
        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
    
        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            _moveInput = Vector2.zero;
        }
        
        private void OnLookPerformed(InputAction.CallbackContext context)
        {
            _lookInput = context.ReadValue<Vector2>();
        }

        private void OnLookCanceled(InputAction.CallbackContext context)
        {
            _lookInput = Vector2.zero;
        }
}
