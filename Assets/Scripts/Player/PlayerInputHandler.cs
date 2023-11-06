using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public float inputMove = 0f;
    public Vector2 inputCursor = Vector2.zero;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;


    void Start() {
        
    }

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += OnJump;
        
    }

    private void Update() {
        inputMove = playerInputActions.Player.LeftRightMovement.ReadValue<float>();
        GetComponent<PlayerMovement>().ReadInput(inputMove);
        if (playerInputActions.Player.Drop.WasPerformedThisFrame() == true) {
            OnDrop();
        }
    }

    public void OnCursor(InputAction.CallbackContext context) {
        inputCursor = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) {
        GetComponent<PlayerMovement>().Jump();
    }

    public void OnDrop() {
        GetComponent<PlayerMovement>().Drop();
    }
    
}
