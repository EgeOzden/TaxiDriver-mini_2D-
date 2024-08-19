using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] GameObject kamera;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = kamera.transform.position + new Vector3(0, 0, -10);
    }
}
