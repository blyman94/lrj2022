using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailgunControl : MonoBehaviour
{
    public List<Vector3> lanePositions;
    [SerializeField] private IntVariable railgunLane;
   public void TryFire()
   {

       Debug.Log("Fired");
       RaycastHit[] hitInfo = Physics.BoxCastAll(lanePositions[railgunLane.Value],
           new Vector3(8, 32, 32), Vector3.forward);
       
                    if(hitInfo.Length > 0 ){
                        foreach(RaycastHit hit in hitInfo)
                        {
                            if (hit.collider != null)
                            {
                                Debug.Log(hit.collider.gameObject.name);
                            }
                        }
                    }
                }
   
}
