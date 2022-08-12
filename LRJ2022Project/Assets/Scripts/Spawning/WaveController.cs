using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] private List<EnemyWaveData> Waves;

    [SerializeField] private IntVariable WaveIndex;

    [SerializeField] private BoolVariable WaveActive;

    [SerializeField] private IntVariable EnemiesToKill;

    [SerializeField] private GameEvent onWaveEnd;
    
    [SerializeField] private GameEvent onGameEnd;

    //Potential Deflection [SerializeField] private EnemyWaveData currentWave;

    //Current Coupled Design
    [SerializeField] private EnemySpawner spawner;

    private void OnEnable()
    {
        WaveIndex.VariableUpdated += CheckGameEnd;

        EnemiesToKill.VariableUpdated += CheckWaveEnd;
    }

    private void OnDisable()
    { 
        WaveIndex.VariableUpdated -= CheckGameEnd;
        EnemiesToKill.VariableUpdated -= CheckWaveEnd;
    }

    private void CheckWaveEnd()
    {
        if (!WaveActive.Value || EnemiesToKill.Value > 0)
        {
            return;
        }

        WaveActive.Value = false;
        onWaveEnd.Raise();
    }

    private void CheckGameEnd()
    {
        if (WaveIndex.Value >= Waves.Count)
        {
            onGameEnd.Raise();
        }
    }

    public void StartWave()
    {
    Debug.Log("Started Wave");
        if (WaveIndex.Value >= Waves.Count)
        {
            Debug.LogError("Invalid Wave Count");
            return;
        }
        
        EnemiesToKill.Value = Waves[WaveIndex.Value].enemyData.Count;
        WaveActive.Value = true;
        
        spawner.SpawnEnemies(new List<GameObject>(Waves[WaveIndex.Value].enemyData));
    }
}
