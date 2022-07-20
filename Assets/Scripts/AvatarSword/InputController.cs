using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class MoveInputEvent : UnityEvent<Vector2>
{
}

//[Serializable]
//public class RotateInputEvent : UnityEvent<float>
//{
//}

public sealed class InputController : MonoBehaviour
{
    [SerializeField] MoveInputEvent moveInputEvent;
    //[SerializeField] RotateInputEvent rotateInputEvent;

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

    //private float rotateInput;
    //[HideInInspector] public bool IsRotatePressed;
    //private void OnRotate(InputAction.CallbackContext context)
    //{
    //    rotateInput = context.ReadValue<float>();
    //    IsRotatePressed = rotateInput != 0;
    //    //Debug.Log($"IsRotatePressed {IsRotatePressed}");
    //    rotateInputEvent.Invoke(rotateInput);
    //}

    [HideInInspector] public bool IsShootPressed;
    private void OnShoot(InputAction.CallbackContext context)
    {
        IsShootPressed = context.ReadValueAsButton();
        //Debug.Log($"IsShootPressed {IsShootPressed}");
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