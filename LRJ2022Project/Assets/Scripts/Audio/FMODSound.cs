using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class FMODSound : MonoBehaviour
{

  
    

    private EventInstance _musicInstance;
    private EventInstance _soundInstance;

    [SerializeField] private float index;








    public void startBackground()
    {
        _musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Level BGM");
        _musicInstance.start();
    }

    

    
    
    public void PlayDamage()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Base Damage");
    }

    public void PlayDeath()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy Death");
    }
    
    
    public void StopMusic()
    {
        _musicInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }
    
  
}
