using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;

    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Debug.Log("We hit " + hit.collider.name + " at " + hit.point);
                //move player to what we hit 
                motor.MoveToPoint(hit.point);
                //stop focusing any objects 
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //check if we hit an interactable 
                //if we did set it as our focus
            }
        }
    }
}
