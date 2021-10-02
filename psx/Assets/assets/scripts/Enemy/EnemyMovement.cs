using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float walkSpeed = 2.5f;
    public float runSpeed = 4f;
    public float runChance = 0.02f;

    public float runTimer = 3;
    public float timestep = 5f;
    private float nexttime;
    private bool reached = false;
    private bool firstView = false;
    public bool hunting = false;

    public Light light;

    public LayerMask layer;
    public float distance;

    [SerializeField] Animator anim;
    [SerializeField] Transform[] targets;
    Transform target;
    public Transform player;

    public NavMeshAgent agent;
    [SerializeField] FieldOfView fov;

    void Start()
    {
        nexttime = Time.time + timestep;
    }

    void Update()
    {
        if (hunting)
        {
            light.intensity = Mathf.Lerp(light.intensity, 1, Time.deltaTime * 4);
        }
        else {
            light.intensity = Mathf.Lerp(light.intensity, 0, Time.deltaTime * 4);
        }
        if (!reached)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (agent.speed == runSpeed) {
                    stopRunning();
                }
                if (hunting)
                {
                    fov.viewAngle = 360;
                    Invoke(nameof(resetViewAngle), 2);

                }
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
        hunting = false;
        target = targets[Random.Range(0, targets.Length)];
        agent.SetDestination(target.position);
        reached = false; 
        firstView = false;
    }
    public void newDestination(Vector3 position)
    {
        if (!firstView)
        {
            firstView = true;
            startRunning();
            CancelInvoke(nameof(stopRunning));
            Invoke(nameof(stopRunning), runTimer / 2);
        }
        else
        {
            if (Random.value < runChance)
            {
                startRunning();
                Invoke(nameof(stopRunning), runTimer);
            }
        }

        agent.SetDestination(position);
        reached = false;
    }

    IEnumerator followPlayerCO()
    {
        while (true)
        {
            newDestination(player.position);
            hunting = true;
            CancelInvoke(nameof(stopRunning));
            Invoke(nameof(stopRunning), runTimer*.8f);
            yield return 0.1f;
        }
    }

    public void followPlayer() {
        StartCoroutine(nameof(followPlayerCO));
        Invoke(nameof(noFollowPlayer),10);
    }
    public void noFollowPlayer()
    {
        StopCoroutine(nameof(followPlayerCO));
    }
    public void startRunning()
    {
        agent.speed = runSpeed;
        anim.SetBool("running", true);

    }
    public void stopRunning()
    {
        agent.speed = walkSpeed;
        anim.SetBool("running", false);
    }

    public void resetViewAngle()
    {
        fov.viewAngle = 180;
    }
}