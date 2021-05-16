using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    public float zoomSpeed = 4f;
    public float minZoom = 5f, maxZoom = 15f;
    public float yawSpeed = 100f; 

    private float currentYaw = 0f; 
    float currentZoom = 10f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }
}
