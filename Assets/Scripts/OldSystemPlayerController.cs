using UnityEngine;

public class OldSystemPlayerController : BasePlayerController
{
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        CheckHorizontalMovement();
        CheckJumping();
    }

    private void CheckHorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        MoveHorizontal(horizontalInput);
    }

    private void CheckJumping()
    {
        bool isTryingToJump = Input.GetKeyDown(jumpKey);
        if (!isTryingToJump) return;
        
        Jump();
    }
}