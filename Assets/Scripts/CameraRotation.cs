﻿using UnityEngine;
using System.Collections;

//Turn off from main camera for VR mode

public class CameraRotation : MonoBehaviour {

    public Transform arm;
    public float speedH = 1.0f;
    public float speedV = 1.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;


    void Start()
    {

#if UNITY_ANDROID
        Input.gyro.enabled = true; //using gyroscope for non VR mode
#endif

    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN

            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            arm.eulerAngles = new Vector3(9.0f,  yaw, 0.0f);
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
#endif

#if UNITY_ANDROID
            yaw -= speedH * Input.gyro.rotationRateUnbiased.y;
            pitch -= speedV * Input.gyro.rotationRateUnbiased.x;
            arm.eulerAngles = new Vector3(9.0f,  yaw, 0.0f);
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
#endif

    }
}
