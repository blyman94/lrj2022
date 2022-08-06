using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStateMachine playerStateMachine;

    public void OnMouseMove(InputAction.CallbackContext context)
    {
        playerStateMachine.MousePosition = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerStateMachine.OnClickGameWorld();
        }
    }
}
