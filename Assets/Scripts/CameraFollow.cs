using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 5f;
    public Transform target;

    public float maxLeft;
    public float maxRight;
    public float maxUp;
    public float maxDown;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);

        // clamp the camera to the bounds
        newPos.x = Mathf.Clamp(newPos.x, maxLeft, maxRight);
        newPos.y = Mathf.Clamp(newPos.y, maxDown, maxUp);

        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
