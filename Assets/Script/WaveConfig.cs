using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spwanRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return this.enemyPrefab;
    }

    public List<Transform> GetWayPoints()
    {
        var wavePoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            wavePoints.Add(child);
        }

        return wavePoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return this.timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return this.spwanRandomFactor;
    }

    public float GetNumberOfEnemies()
    {
        return this.numberOfEnemies;
    }

    public float GetmoveSpeed()
    {
        return this.moveSpeed;
    }
}
