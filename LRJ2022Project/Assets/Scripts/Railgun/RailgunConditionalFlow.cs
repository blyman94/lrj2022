
using UnityEngine;
using UnityEngine.Events;

public class RailgunConditionalFlow : MonoBehaviour
{
    [SerializeField] private bool firstTrigger = true;

    [SerializeField] private UnityEvent Response;
    
    public void FirstTriggerCheck()
    {
        if (firstTrigger)
        {
            firstTrigger = false;
            Response.Invoke();  
        }
    }
}
