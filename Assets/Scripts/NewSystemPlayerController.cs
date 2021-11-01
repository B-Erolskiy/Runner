using System;
using UnityEngine.InputSystem;

public class NewSystemPlayerController : BasePlayerController
{
    private PlayerControls _playerControls;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        
        CheckHorizontalMovement();
    }

    private void CheckHorizontalMovement()
    {
        var movement = _playerControls.Player.HorizontalMove.ReadValue<float>();
        MoveHorizontal(movement);
    }

    private void OnEnable()
    {
        _playerControls.Enable();
        _playerControls.Player.Jump.performed += JumpOnPerformed;
    }

    private void JumpOnPerformed(InputAction.CallbackContext obj)
    {
        Jump();
    }

    private void OnDisable()
    {
        _playerControls.Player.Jump.performed -= JumpOnPerformed;
        _playerControls.Disable();
    }

    private void OnDestroy()
    {
        _playerControls.Dispose();
    }
}