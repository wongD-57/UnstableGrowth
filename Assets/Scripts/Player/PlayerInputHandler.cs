using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    float inputMove = 0f;

    private string characterColor;
    Vector2 inputCursor = Vector2.zero;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    GameObject playerCursorObject;
    public PlayerMovement PMComponent;
    public PlayerCollisions PCComponent;

    public PlayerCursor PLCScript;

    void Start() {

        characterColor = gameObject.tag;
        
        if(!TryGetComponent<PlayerMovement>(out PMComponent))
        {
            Debug.Log("PlayerCursor component not found.");
        } 

        if(!TryGetComponent<PlayerCollisions>(out PCComponent))
        {
            Debug.Log("PlayerCollisions component not found.");
        } 
        
    }

    private void Awake() {
        // playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += OnJump;    
    }

    private void Update() {
        inputMove = playerInputActions.Player.LeftRightMovement.ReadValue<float>();

        if(characterColor == "Orange")
        {
            orangeMovementManager();
            orangeCursorManager();

        }else if(characterColor == "Blue") 
        {
            blueMovementManager();
            blueCursorManager();
        }



        inputCursor = playerInputActions.Player.Cursor.ReadValue<Vector2>();
        
        if (playerInputActions.Player.Grow.IsPressed()) {
            OnGrow();
        }

        if (playerInputActions.Player.Shrink.IsPressed()) {
            OnShrink();
        }
    }

    public void OnJump(InputAction.CallbackContext context) {
        PMComponent.Jump();
    }

    public void OnDrop(bool dropInput) {
        print("OnDrop Fired");
    }
    
    public void OnGrow() {
        playerCursorObject.GetComponent<PlayerCursor>().MakeGrow();
    }

    public void OnShrink() {
        playerCursorObject.GetComponent<PlayerCursor>().MakeShrink();
    }

    public void orangeMovementManager()
    {
        if(Input.GetKey("a"))
        {
            PMComponent.ReadInput(-1);
        } else if(Input.GetKey("d"))
        {
            PMComponent.ReadInput(1);
        } else {
            PMComponent.ReadInput(0);
        }

        if(Input.GetKeyDown("w"))
        {
            PMComponent.Jump();
        }

        if(Input.GetKey("s"))
        {
            PCComponent.dropPressed = true;
        } else {
            PCComponent.dropPressed = false;
        }
    }

    public void orangeCursorManager()
    {

        PLCScript.xInputValue = 0;
        PLCScript.yInputValue = 0;
        if(Input.GetKey("h"))
        {
            PLCScript.xInputValue+=1;
        }
        
        if(Input.GetKey("f"))
        {
            PLCScript.xInputValue-=1;
        }

        if(Input.GetKey("t"))
        {
            PLCScript.yInputValue+=1;
        }

        if(Input.GetKey("g"))
        {
            PLCScript.yInputValue-=1;
        }

        // print("x:"+PLCScript.xInputValue+" y:"+PLCScript.yInputValue);
    }

    public void blueMovementManager()
    {
        if(Input.GetKey("j"))
        {
            PMComponent.ReadInput(-1);
        } else if(Input.GetKey("l"))
        {
            PMComponent.ReadInput(1);
        } else {
            PMComponent.ReadInput(0);
        }

        if(Input.GetKeyDown("i"))
        {
            PMComponent.Jump();
        }

        if(Input.GetKey("k"))
        {
            PCComponent.dropPressed = true;
        } else {
            PCComponent.dropPressed = false;
        }
    }

    public void blueCursorManager()
    {

        PLCScript.xInputValue = 0;
        PLCScript.yInputValue = 0;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            PLCScript.xInputValue+=1;
        }
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            PLCScript.xInputValue-=1;
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            PLCScript.yInputValue+=1;
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            PLCScript.yInputValue-=1;
        }

        // print("x:"+PLCScript.xInputValue+" y:"+PLCScript.yInputValue);
    }
}
