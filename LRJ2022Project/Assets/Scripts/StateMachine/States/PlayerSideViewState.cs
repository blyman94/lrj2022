using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSideViewState : PlayerBaseState
{
    private int weaponIdx = 0;
    private float reloadTime;

    public PlayerSideViewState(PlayerStateMachine context)
    {
        Perspective = PerspectiveEnum.SIDE;
        Context = context;
    }

    public override void EnterState()
    {
        Context.SwitchToSideViewEvent.Raise();
        reloadTime = GetWeapon().weaponCooldown;
    }

    public override void ExitState()
    {
        
    }

    public override void OnClickGameWorld()
    {
        if (reloadTime <= 0)
        {
            reloadTime = GetWeapon().weaponCooldown;
            WeaponData currentWeapon = GetWeapon();
            Vector2 mousePosition = GetMousePosition();
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(mousePosition.x / 64, mousePosition.y / 64, 0.0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log("Bullet Fired");
                EnemyDetection(hit.transform.gameObject);
            }
        }
    }

    private Vector2 GetMousePosition()
    {
        return Context.MousePosition;
    }

    private WeaponData GetWeapon()
    {
        if (weaponIdx >= Context.Weapons.Count)
        {
            Debug.Log("Index Exceeds Weapons List Length");
        }
        return Context.Weapons[weaponIdx];
    }

    private GameObject GetCrossHair()
    {
        return Context.FpsCrossHair;
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
        if (reloadTime > 0)
        {
            reloadTime -= Time.deltaTime;
        }
        Vector2 mousePosition = GetMousePosition();
        // Debug.Log(new Vector2(mousePosition.x / 64, mousePosition.y / 64));
        GetCrossHair().transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        GetCrossHair().GetComponent<Image>().fillAmount = 1 - Math.Max(reloadTime, 0) / GetWeapon().weaponCooldown;
    }
}
