using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    float inputMove = 0f;
    Vector2 inputCursor = Vector2.zero;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    GameObject playerCursorObject;


    void Start() {
        playerCursorObject = GameObject.Find("Cursor");
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

        inputCursor = playerInputActions.Player.Cursor.ReadValue<Vector2>();
        playerCursorObject.GetComponent<PlayerCursor>().ReadInput(inputCursor);
        
        if (playerInputActions.Player.Grow.IsPressed()) {
            OnGrow();
        }

        if (playerInputActions.Player.Shrink.IsPressed()) {
            OnShrink();
        }
        
        OnDrop(playerInputActions.Player.Drop.IsPressed());
        
    }

    public void OnJump(InputAction.CallbackContext context) {
        GetComponent<PlayerMovement>().Jump();
    }

    public void OnDrop(bool dropInput) {
        GetComponent<PlayerCollisions>().Drop(dropInput);
    }
    
    public void OnGrow() {
        playerCursorObject.GetComponent<PlayerCursor>().MakeGrow();
    }

    public void OnShrink() {
        playerCursorObject.GetComponent<PlayerCursor>().MakeShrink();
    }
}
