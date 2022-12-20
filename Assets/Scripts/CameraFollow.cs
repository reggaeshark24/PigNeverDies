using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   // speed at witch camera follows target
    public float FollowSpeed = 2f;
    // fixes view on vertical axis
    public float yOffset = 1f;
    // selects target
    public Transform target;


    // Update is called once per frame
    void Update()
    { // follow target
        Vector3 newPos = new Vector3(target.position.x,target.position.y+yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }
}
