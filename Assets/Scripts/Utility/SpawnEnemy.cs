using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // public GameObject[] enemy
    public GameObject spawnCenter;
    private void FixedUpdate()
    {

    }

    public void Spawn(GameObject enemy)
    {
        Instantiate(enemy, GenerateSpawnPoint(), Quaternion.Euler(0.0f, 0.0f, 0.0f));
    }

    public Vector3 GenerateSpawnPoint()
    {
        Vector2 origin = transform.position;
        Vector2 range = transform.localScale / 2.0f;
        Vector2 randomRange = new Vector2(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y));
        Vector2 spawnPoint = origin + randomRange;

        return spawnPoint;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.2f);
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
