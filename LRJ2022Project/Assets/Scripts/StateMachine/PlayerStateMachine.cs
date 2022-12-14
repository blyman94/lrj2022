using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("Game Events")]
    public GameEvent SwitchToFrontViewEvent;
    public GameEvent SwitchToSideViewEvent;
    public GameEvent SwitchToTopViewEvent;

    [Header("Side View State Data")]
    public LayerMask Mask;
    public GameObject FpsCrossHair;
    public List<WeaponData> Weapons;
    public GameEvent WeaponReload;
    public GameEvent WeaponFire;


    [Header("State Data")]
    public float BombCooldownTime;

    public FloatVariable bombCooldown;
    public bool IsFirstBomb { get; set; } = true;
    public GameObject BombCrosshairObject;
    public GameObject BombProjectilePrefab;
    public GameEvent BombRelease;
    public GameEvent BombReady;
    
    private PlayerBaseState _currentState;

    // States
    private PlayerFrontViewState _frontViewState;
    private PlayerSideViewState _sideViewState;
    private PlayerTopViewState _topViewState;

    public Vector2 MousePosition { get; set; }

    private void Awake()
    {
        _frontViewState = new PlayerFrontViewState(this);
        _sideViewState = new PlayerSideViewState(this);
        _topViewState = new PlayerTopViewState(this);
    }

    private void Start()
    {
        _currentState = _topViewState;
        _currentState.EnterState();
    }

    private void Update()
    {
        _currentState.UpdateState();
    }

    public void SwitchStates(Perspective switchToPerspective)
    {
        // Return out of the switch state call is to the same state.
        if (_currentState.Perspective == switchToPerspective.PerspectiveEnum)
        {
            Debug.Log("Called Same State A");
            return;
        }

        PlayerBaseState newState;

        switch (switchToPerspective.PerspectiveEnum)
        {
            case (PerspectiveEnum.FRONT):
                newState = _frontViewState;
                break;
            case (PerspectiveEnum.SIDE):
                newState = _sideViewState;
                break;
            case (PerspectiveEnum.TOP):
                newState = _topViewState;
                break;
            default:
                newState = _currentState;
                Debug.LogError("Perspective not recognized by " +
                    "PlayerStateMachine.SwitchStates().");
                break;
        }

        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
        Debug.Log(_currentState.Perspective.ToString());
    }

    public void SwitchStates(PerspectiveEnum switchToPerspective)
    {
        // Return out of the switch state call is to the same state.
        if (_currentState.Perspective == switchToPerspective)
        {
            return;
        }

        PlayerBaseState newState;

        switch (switchToPerspective)
        {
            case (PerspectiveEnum.FRONT):
                newState = _frontViewState;
                break;
            case (PerspectiveEnum.SIDE):
                newState = _sideViewState;
                break;
            case (PerspectiveEnum.TOP):
                newState = _topViewState;
                break;
            default:
                newState = _currentState;
                Debug.LogError("Perspective not recognized by " +
                    "PlayerStateMachine.SwitchStates().");
                break;
        }

        _currentState.ExitState();
        _currentState = newState;
        _currentState.EnterState();
        Debug.Log(_currentState.Perspective.ToString());
    }

    public void OnClickGameWorld()
    {
        _currentState.OnClickGameWorld();
    }

    public void SpawnBombAtPosition(Vector3 spawnPos)
    {
        BombRelease.Raise();
        Instantiate(BombProjectilePrefab, spawnPos, Quaternion.identity);
    }
}
