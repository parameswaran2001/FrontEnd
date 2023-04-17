
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform camTarg;
    public Vector3 camOffset;
    [Range(1.0f, 25.0f)] public float smoothFactor;
    private bool LookAtTarget = true;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = transform.position - camTarg.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = camTarg.transform.position + camOffset;
        transform.position = Vector3.Slerp(transform.position,newPosition, smoothFactor);

        if (LookAtTarget)
        {
            transform.LookAt(camTarg);
        }
    }
}