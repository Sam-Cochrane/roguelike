using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Takes an object as a thing to follow
    public Transform follow;

    private void Start()
    {
        follow = GameObject.FindGameObjectWithTag("Player").transform;
    }
    //Called once a frame
    void FixedUpdate()
    {

        transform.position = new Vector3(Mathf.Clamp(follow.position.x, -7, 7), Mathf.Clamp(follow.position.y, -5, 4), -12);

        //Moves the camera to follow the player
       // transform.position = new Vector3(follow.position.x, follow.position.y, -12);
    }
}
