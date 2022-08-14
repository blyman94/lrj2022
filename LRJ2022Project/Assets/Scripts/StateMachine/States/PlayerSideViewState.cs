using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSideViewState : PlayerBaseState
{
    private int weaponIdx = 0;
    private float reloadTime;
    private bool isReloading = false;
    private List<GameObject> bullets = new List<GameObject>();

    public PlayerSideViewState(PlayerStateMachine context)
    {
        Context = context;
        Perspective = PerspectiveEnum.SIDE;
        isReloading = true;
        reloadTime = GetWeapon().weaponReloadTime;
        GetWeapon().Init();
        InitBulletDisplay();
    }

    public override void EnterState()
    {
        Context.SwitchToSideViewEvent.Raise();
        GetCrossHair().transform.position = new Vector3(32, 32, 0);
    }

    public override void ExitState()
    {
        
    }

    public override void OnClickGameWorld()
    {
        if (reloadTime <= 0)
        {
            if (GetWeapon().OutOfBullets())
            {
                ReloadWeapon();
            } else {
                FireWeapon();
            }
        }
    }
    
    private void FireWeapon()
    {
        WeaponData currentWeapon = GetWeapon();
        currentWeapon.Fire();
        UpdateBulletDisplay();
        Vector2 mousePosition = GetMousePosition();
        Vector3 origin = new Vector3(64, mousePosition.y, mousePosition.x);
        RaycastHit hit;
        if (Physics.Raycast(origin, Vector3.left, out hit, currentWeapon.weaponRange, Context.Mask))
        {
            EnemyDetection(hit.transform.gameObject);
        }
        reloadTime = currentWeapon.weaponCooldown; 
    }

    private void ReloadWeapon()
    {
        WeaponData currentWeapon = GetWeapon();
        reloadTime = currentWeapon.weaponReloadTime;
        currentWeapon.Reload();
        ResetBulletDisplay();
        isReloading = true;
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
            target.GetComponent<Enemy>().TakeDamage(GetWeapon().bulletDamage);
        }
    }

    private void OnFrameFillCrossHairReload(float time)
    {
        GetCrossHair().GetComponent<Image>().fillAmount = 1 - Math.Max(reloadTime, 0) / time;
    }

    private void OnFrameFollowMouse()
    {
        Vector2 mousePosition = GetMousePosition();
        GetCrossHair().transform.position = new Vector3(Mathf.RoundToInt(mousePosition.x), Mathf.RoundToInt(mousePosition.y), 0);
    }

    private void OnFrameResetReload()
    {
        if (reloadTime > 0)
        {
            reloadTime -= Time.deltaTime;
        }
        else
        {
            reloadTime = 0;
            isReloading = false;
        }
    }
    
    public override void OnReload()
    {
        if (!isReloading)
        {
            ReloadWeapon();
        }
    }

    private void InitBulletDisplay()
    {
        float xCounter = Context.BRBulletDisplay.x;
        float yConstant = Context.BRBulletDisplay.y;
        for (int i = 0; i < GetWeapon().remainingBullets; i++)
        {
            GameObject bullet = Context.BulletPrefab;
            UnityEngine.Object.Instantiate(bullet, new Vector3(xCounter, yConstant, 0), Quaternion.identity);
            bullets.Add(bullet);
            Debug.Log("Instantiated bullet at： " + new Vector2(xCounter, yConstant));
            xCounter += Context.BulletDisplayDistance;
        }
    }

    private void UpdateBulletDisplay()
    {
        bullets[GetWeapon().remainingBullets].GetComponent<Image>().enabled = false;
    }

    private void ResetBulletDisplay()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            bullets[i].GetComponent<Image>().enabled = true;
        }
    }

    public override void UpdateState()
    {
        OnFrameResetReload();
        OnFrameFollowMouse();
        if (isReloading)
        {
            OnFrameFillCrossHairReload(GetWeapon().weaponReloadTime);
        }
        else
        {
            OnFrameFillCrossHairReload(GetWeapon().weaponCooldown);
        }
    }
}
