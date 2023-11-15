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


    /**
    If you initialise components once instead of calling "GetComponent" repeatedly 
    it should speed up computation and coding. I have made an example with "PlayerMovement".

    I have left your original lines commented out in case you would like to revert them.
    Please let me know if you would like me to stop meddeling in your code.
    */
    public PlayerMovement PMComponent;

    void Start() {
        playerCursorObject = GameObject.Find("Cursor");

        if(TryGetComponent<PlayerMovement>(out PMComponent))
        {
            //  PlayerMovement component assigned to the PMComponent variable.
        } else {
            Debug.Log("PlayerCursor component not found.");
        }
    }

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += OnJump;    
    }

    private void Update() {
        inputMove = playerInputActions.Player.LeftRightMovement.ReadValue<float>();
        // GetComponent<PlayerMovement>().ReadInput(inputMove);
        PMComponent.ReadInput(inputMove);

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
        // GetComponent<PlayerMovement>().Jump();
        PMComponent.Jump();
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
