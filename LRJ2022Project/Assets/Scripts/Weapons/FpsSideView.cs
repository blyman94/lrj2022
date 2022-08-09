using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsSideView : MonoBehaviour
{
    public PlayerStateMachine state;
    public int range = 64;
    public bool isActive = false;
    public Vector2 mousePosition;
    public List<WeaponData> weapons;
    public int weaponIdx;
    public GameObject crossHair;

    void Awake()
    {
        this.weaponIdx = 0;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if (isActive)
        {
            Debug.Log(state.MousePosition);
            mousePosition = state.MousePosition;
            crossHair.transform.position = new Vector3(0, mousePosition.y, mousePosition.x);
        }
    }

    public void Activate()
    {
        isActive = true;
    }

    WeaponData GetWeapon()
    {
        return weapons[weaponIdx];
    }

    void FireBullet()
    {
        
        Ray interactionRay = Camera.main.ViewportPointToRay(new Vector3(mousePosition.x, mousePosition.y, 0.0f));
        RaycastHit hit;

        if (Physics.Raycast(interactionRay, out hit, range))
        {
            Debug.Log("Bullet Fired");
            GetWeapon().Fire();
            EnemyDetection(hit.transform.gameObject);
        }

    }

    void EnemyDetection(GameObject target)
    {
        if (target.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit");
        }
    }
}
