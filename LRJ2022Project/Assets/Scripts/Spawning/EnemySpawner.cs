using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Vector3ListVariable lanes;
    //Potential Deflection [SerializeField] private EnemyWaveData currentWave;
    public void SpawnEnemies(List<GameObject> enemies)
    {
        StartCoroutine(EnemyGenerate( enemies));
    }

    IEnumerator EnemyGenerate(List<GameObject> enemies)
    {
        foreach (int i in Enumerable.Range(0, enemies.Count).OrderBy(x => Random.value))
        {
            Instantiate(enemies[i],
                lanes.Lanes[Random.Range(0, lanes.Lanes.Count)],
                Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
}
