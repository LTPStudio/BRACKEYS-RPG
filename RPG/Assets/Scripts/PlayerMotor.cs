using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    public float lookAtSpeed = 20f; 

    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator UpdateFollowTarget()
    {
        while (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
            yield return new WaitForSeconds(.05f);
        }
        //Debug.Log("Target is null. Stopping follow coroutine");
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        StopAllCoroutines();
        agent.stoppingDistance = newTarget.radius * .8f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform.transform;
        StartCoroutine(UpdateFollowTarget());
    }
    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 dirXZ = new Vector3(direction.x, 0, direction.z);
        Quaternion lookRotation = Quaternion.LookRotation(dirXZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookAtSpeed);
    }
}
