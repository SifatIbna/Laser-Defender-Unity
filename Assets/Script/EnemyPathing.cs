using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    float movementSpeed;

    int wayPointIndex = 0;
    List<Transform> wayPoints;
    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
        movementSpeed = waveConfig.GetmoveSpeed();
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (wayPointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            var movementThisFrame = movementSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                wayPointIndex++;

            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
