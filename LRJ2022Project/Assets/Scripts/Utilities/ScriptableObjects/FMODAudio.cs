using UnityEngine;

[CreateAssetMenu]
public class FMODAudio : ScriptableObject
{
    public string AudioEvent;

    public void PlayAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(AudioEvent);

    }
}
