using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyWaveData> Waves;

    [SerializeField] private IntVariable WaveIndex;

    [SerializeField] private BoolVariable WaveStarted;

    [SerializeField] private IntVariable EnemiesToKill;

    [SerializeField] private GameEvent onWaveEnd;
    
    
    public void StartWave()
    {
        if (WaveIndex.Value > Waves.Count)
        {
            Debug.LogError("Invalid Wave Count");
            return;
        }
    }

    private void RaiseDied()
    {
        
    }
    public void SpawnEnemies()
    {
       foreach(GameObject enemy in Waves[WaveIndex.Value].enemyData)
       {
      
       }
    }
}
