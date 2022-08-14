using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class FMODSound : MonoBehaviour
{

  /**
   * SFX:
    event:/SFX/Background Static (this loops, so use the instance method instead of playoneshot)
    event:/SFX/Base Damage
    event:/SFX/Bomb Explode
    event:/SFX/Bomb Release
    event:/SFX/Enemy Death
    event:/SFX/Front View Change
    event:/SFX/Game Over
    event:/SFX/Gun Reload
    event:/SFX/Laser Button
    event:/SFX/Laser Charge + Fire (this has both the charge-up and firing atm, pending further adjustment)
    event:/SFX/Last Life (this loops, so use the instance method instead of playoneshot)
    event:/SFX/Ready 1
    event:/SFX/Ready 2
    event:/SFX/Side View Change
    event:/SFX/Top View Change
    event:/SFX/Victory
    MX:
    event:/MX/Level BGM (loops, use instance method)
    ^^ currently layers based on wave number - the fmod p
  **/
  
    

    private EventInstance _musicInstance;
    private EventInstance _soundInstance;

    [SerializeField] private IntVariable WaveIndex;

    public void StartLevelMusic()
    {
        _musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/MX/Level BGM");
        _musicInstance.start();
        _soundInstance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Background Static");
        _soundInstance.start();
    }
    
    private void OnEnable()
    {
        WaveIndex.VariableUpdated += UpdateGameplayLayers;

    }
    
    private void OnDisable()
    {
        WaveIndex.VariableUpdated -= UpdateGameplayLayers;
    }
    
    private void UpdateGameplayLayers()
    {
        int index = 0;
        index = WaveIndex.Value;
        if (index > 4)
        {
            index = 4;
        }

        FMOD.RESULT result = FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Wave Number", index);
        Debug.Log(result);
     
    }
    
    public void StopMusic()
    {
        _musicInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }
    
  
}
