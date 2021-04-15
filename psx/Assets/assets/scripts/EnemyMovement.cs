using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float timestep = 5f;
    private float nexttime;
    private bool reached=false;

    public LayerMask layer;
    public float distance;

    [SerializeField] Animator anim;
    [SerializeField] Transform[] targets;
    Transform target;

    public NavMeshAgent agent;

    void Start()
    {
        nexttime = Time.time + timestep;
    }

    void Update()
    {
        if (!reached)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                Invoke(nameof(newRandomDestination), 2);
                reached = true;
            }
        }
        if (agent.velocity.magnitude > .1f)
            anim.SetBool("walking", true);
        else
            anim.SetBool("walking", false);

        //aqui o método antigo que ele abre as portas
        //Collider[] hitColliders = Physics.OverlapSphere(transform.position, distance, layer);
        
        //foreach (Collider hitCollider in hitColliders)
        //{
            //hitCollider.GetComponent<DoorController>().ForceOpen();
        //}
    }
    public void newRandomDestination() {
        target = targets[Random.Range(0, targets.Length)];
        agent.SetDestination(target.position);
        reached = false;
    }
}