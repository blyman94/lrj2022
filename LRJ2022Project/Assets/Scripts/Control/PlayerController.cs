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

    public void OnSwitchToFrontView(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerStateMachine.SwitchStates(PerspectiveEnum.FRONT);
        }
    }

    public void OnSwitchToSideView(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerStateMachine.SwitchStates(PerspectiveEnum.SIDE);
        }
    }

    public void OnSwitchToTopView(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerStateMachine.SwitchStates(PerspectiveEnum.TOP);
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerStateMachine.OnClickGameWorld();
        }
    }
}
