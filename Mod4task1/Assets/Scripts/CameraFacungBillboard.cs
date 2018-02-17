using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacungBillboard : MonoBehaviour {

    private Transform mainCameraTransform;
    private void Update()
    {
        mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        transform.LookAt(mainCameraTransform);
    }

}
