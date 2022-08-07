using UnityEngine;
public class PlayerSideViewState : PlayerBaseState
{
    private int weaponIdx = 0;

    public PlayerSideViewState(PlayerStateMachine context)
    {
        Context = context;
        Perspective = PerspectiveEnum.SIDE;
    }

    public override void EnterState()
    {
        Context.SwitchToSideViewEvent.Raise();
    }

    public override void ExitState()
    {
        
    }

    public override void OnClickGameWorld()
    {
        Debug.Log("Registered");
        WeaponData currentWeapon = GetWeapon();
        Vector2 mousePosition = GetMousePosition();
        Ray interactionRay = Camera.main.ViewportPointToRay(new Vector3(mousePosition.x, mousePosition.y, 0.0f));
        RaycastHit hit;
        if (Physics.Raycast(interactionRay, out hit, currentWeapon.weaponRange))
        {
            Debug.Log("Bullet Fired");
            EnemyDetection(hit.transform.gameObject);
        }
    }

    private Vector2 GetMousePosition()
    {
        return Context.MousePosition;
    }

    private WeaponData GetWeapon()
    {
        if (weaponIdx >= Context.weapons.Count)
        {
            Debug.Log("Index Exceeds Weapons List Length");
        }
        return Context.weapons[weaponIdx];
    }

    private GameObject GetCrossHair()
    {
        return Context.fpsCrossHair;
    }

    private void EnemyDetection(GameObject target)
    {
        if (target.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
        }
    }

    public override void UpdateState()
    {
        Vector2 mousePosition = GetMousePosition();
        GetCrossHair().transform.position = new Vector3(0, mousePosition.y, mousePosition.x);
    }
}
