using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
    void Update()
    {
        var camera = Camera.main;

        transform.LookAt(transform.position + camera.transform.rotation * Vector3.back,
            camera.transform.rotation * Vector3.up);
    }
}