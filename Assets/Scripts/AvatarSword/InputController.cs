using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable] public class MoveInputEvent : UnityEvent<Vector2> {}
[Serializable] public class LookInputEvent : UnityEvent<Vector2> {}

public sealed class InputController : MonoBehaviour
{
    [SerializeField] MoveInputEvent moveInputEvent;
    [SerializeField] LookInputEvent lookInputEvent;

    Controls controls;
    private void Awake()
    {
        controls = new Controls();

        controls.Gameplay.Move.started += OnMove;
        controls.Gameplay.Move.canceled += OnMove;
        controls.Gameplay.Move.performed += OnMove;

        controls.Gameplay.Shoot.started += OnShoot;
        controls.Gameplay.Shoot.canceled += OnShoot;
        controls.Gameplay.Shoot.performed += OnShoot;

        controls.Gameplay.Look.started += OnLook;
        controls.Gameplay.Look.canceled += OnLook;
        controls.Gameplay.Look.performed += OnLook;
    }

    private Vector2 moveInput;
    [HideInInspector] public bool IsMovePressed;
    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMovePressed = moveInput != Vector2.zero;
        //Debug.Log($"IsMovePressed {IsMovePressed}");
        moveInputEvent.Invoke(moveInput);
    }

    [HideInInspector] public bool IsShootPressed;
    private void OnShoot(InputAction.CallbackContext context)
    {
        IsShootPressed = context.ReadValueAsButton();
        //Debug.Log($"IsShootPressed {IsShootPressed}");
    }

    private Vector2 lookInput;
    [HideInInspector] public bool IsLookPressed;
    private void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        IsLookPressed = lookInput != Vector2.zero;
        //Debug.Log($"IsLookPressed {IsLookPressed}");
        lookInputEvent.Invoke(lookInput);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}