using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField] private int playerIndex = 0;
    // private PlayerInput playerInput;
    // private PlayerInputActions playerInputActions;
    [SerializeField] private string keyUp = "w";
    [SerializeField] private string keyDown = "s";
    [SerializeField] private string keyLeft = "a";
    [SerializeField] private string keyRight = "d";
    [SerializeField] private string keyCursorUp = "t";
    [SerializeField] private string keyCursorDown = "g";
    [SerializeField] private string keyCursorLeft = "f";
    [SerializeField] private string keyCursorRight = "h";
    [SerializeField] private string keyGrow = "r";
    [SerializeField] private string keyShrink = "y";

    private float inputMove = 0f;
    private float inputCursorHor = 0f;
    private float inputCursorVer = 0f;
    Vector2 inputCursor = Vector2.zero;

    GameObject playerCursorObject;


    void Start() {
        playerCursorObject = gameObject.transform.parent.GetChild(0).gameObject;
    }

    // private void Awake() {
    //     playerInput = GetComponent<PlayerInput>();

    //     if (playerIndex == 0) {
    //         playerInputActions = new PlayerInputActions();
    //     }

    //     playerInputActions.Player.Enable();
    //     playerInputActions.Player.Jump.performed += OnJump;   
    // }

    private void Update() {

        // Read the Input from the Player

        inputMove = 0;
        // inputMove = playerInputActions.Player.LeftRightMovement.ReadValue<float>();
        if (Input.GetKey(keyLeft)) {
            inputMove -= 1;
        }
        if (Input.GetKey(keyRight)) {
            inputMove += 1;
        }
        GetComponent<PlayerMovement>().ReadInput(inputMove);

        inputCursorHor = 0;
        inputCursorVer = 0;
        if (Input.GetKey(keyCursorUp)) {
            inputCursorVer += 1;
        }
        if (Input.GetKey(keyCursorDown)) {
            inputCursorVer -= 1;
        }
        if (Input.GetKey(keyCursorLeft)) {
            inputCursorHor -= 1; 
        }
        if (Input.GetKey(keyCursorRight)) {
            inputCursorHor += 1;
        }
        inputCursor = new Vector2(inputCursorHor, inputCursorVer);
        inputCursor.Normalize();
        // inputCursor = playerInputActions.Player.Cursor.ReadValue<Vector2>();
        playerCursorObject.GetComponent<PlayerCursor>().ReadInput(inputCursor);
        
        if (Input.GetKey(keyGrow)) {
        //if (playerInputActions.Player.Grow.IsPressed()) {
            OnGrow();
        }

        if (Input.GetKey(keyShrink)) {
        // if (playerInputActions.Player.Shrink.IsPressed()) {
            OnShrink();
        }
        
        if (Input.GetKey(keyDown)) {
        // OnDrop(playerInputActions.Player.Drop.IsPressed());
            OnDrop(true);
        } else {
            OnDrop(false);
        }

        if (Input.GetKeyDown(keyUp)) {
            GetComponent<PlayerMovement>().Jump();
        }
        
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

    public void orangeMovementManager()
    {
        if(Input.GetKey("a"))
        {
            print("A!");
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
    }
}
