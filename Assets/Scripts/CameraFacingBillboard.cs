using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFacingBillboard : MonoBehaviour
    {
        void Update()
        {
            var camera1 = Camera.main;

            transform.LookAt(transform.position + camera1.transform.rotation * Vector3.back,
            camera1.transform.rotation * Vector3.up);
        }
    }
}