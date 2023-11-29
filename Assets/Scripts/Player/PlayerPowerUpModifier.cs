using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpModifier : MonoBehaviour
{
    
    private float baseMoveSpeed;
    private float baseJumpForce;
    private float baseGrowRate;
    private float baseShrinkRate;

    private bool movePower_State = false;
    [SerializeField] private float movePower_Multiplier = 1.3f;
    [SerializeField] private float movePower_Duration = 3f;
    private float movePower_TimeStart;

    private bool jumpPower_State = false;
    [SerializeField] private float jumpPower_Multiplier = 1.3f;
    [SerializeField] private float jumpPower_Duration = 3f;
    private float jumpPower_TimeStart;
    
    // Start is called before the first frame update
    void Start()
    {
        baseMoveSpeed = GetComponent<PlayerMovement>().moveSpeed;

        baseJumpForce = GetComponent<PlayerMovement>().jumpForce;
    }

    void Update() {
        if (movePower_State) {
            if ((movePower_TimeStart - Time.time) > movePower_Duration) {
                MovePowerDown();
            }
        }
        if (jumpPower_State) {
            if ((jumpPower_TimeStart - Time.time) > jumpPower_Duration) {
                JumpPowerDown();
            }
        }
    }

    void MovePowerUp() {

        movePower_State = true;

        GetComponent<PlayerMovement>().moveSpeed = baseMoveSpeed * movePower_Multiplier;

        movePower_TimeStart = Time.time;
    }

    void MovePowerDown() {
        movePower_State = false;

        GetComponent<PlayerMovement>().moveSpeed = baseMoveSpeed;
    }

    void JumpPowerUp() {
        jumpPower_State = true;

        GetComponent<PlayerMovement>().jumpForce = baseJumpForce * jumpPower_Multiplier;

        jumpPower_TimeStart = Time.time;
    }

    void JumpPowerDown() {
        jumpPower_State = false;

        GetComponent<PlayerMovement>().jumpForce = baseJumpForce;
    }

    void OnCollisionEnter(Collision collision) {
        GameObject col = collision.collider.gameObject;
        if (col.layer == 14) {
            if (col.name.Contains("Jump")) {
                JumpPowerUp();
            } else if (col.name.Contains("Move")) {
                MovePowerUp();
            }
        }
    }
}
