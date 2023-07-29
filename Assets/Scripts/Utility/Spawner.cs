using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform follow;

    public GameObject[] spawnedEnemies;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            follow = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (follow != null)
        {
            transform.position = new Vector3(follow.position.x, follow.position.y, follow.position.z);
        }
    }

}
