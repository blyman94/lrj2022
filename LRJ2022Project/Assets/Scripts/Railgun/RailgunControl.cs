using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunControl : MonoBehaviour
{
    [SerializeField] private List<Vector3> lanePositions;
    [SerializeField] private IntVariable railgunLane;

    [SerializeField] private int damage;
    
   public void TryFire()
   {
       Debug.Log("Fired");
       RaycastHit[] hitInfo = Physics.BoxCastAll(lanePositions[railgunLane.Value],
           new Vector3(8, 32, 32), Vector3.forward);

        if(hitInfo.Length > 0 ){
            foreach(RaycastHit hit in hitInfo)
            {
                if (hit.collider != null && hit.collider.gameObject.GetComponent<Enemy>() != null)
                {
                    hit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
    }
}
