using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class VeioTrigger : MonoBehaviour
{
    private Menu menu;
    private GameObject player;
    [SerializeField] GameObject veio;
    [SerializeField] GameObject veioMesh;
    [SerializeField] GameObject veioParticle;
    [SerializeField] GameObject veia;
    [SerializeField] GameObject veiaCollider;
    [SerializeField] AudioSource caixaoQuebrando;
    [SerializeField] PlayerMovement playerMove;
    [SerializeField] PlayerCamera playerCam;
    [SerializeField] Transform lookAt;
    [SerializeField] Transform moveTo;
    [SerializeField] GameObject[] livros;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactive") {
            caixaoQuebrando.Play();
            veioParticle.SetActive(true);
            menu.openDialogueBar();
            veio.GetComponent<Animator>().SetTrigger("levantar");
            playerCam.lookAt(lookAt);
            playerCam.fovTo(45);
            playerMove.moveAt(moveTo.position);
            player.GetComponent<Pickup>().interactive = false;

        }
    }
    public void callDialogue() {
        menu.dialogueMessage("veioDialogue");
    }
    public void semiUnlock()
    {
        foreach (GameObject livro in livros)
        {
            livro.SetActive(true);
        }
        player.GetComponent<Pickup>().interactive = true;
        GetComponent<Collider>().enabled = false;
        Destroy(veia);
        Destroy(veiaCollider);
        playerCam.noFovTo();
        playerCam.noLookAt();
        playerMove.noMoveAt();
        menu.recalculateObjectives();
    }

    public void unlock() {
        veio.GetComponent<NavMeshAgent>().enabled = true;
        veio.GetComponent<FieldOfView>().start();
        veio.GetComponent<EnemyMovement>().enabled = true;
        veioMesh.GetComponent<CapsuleCollider>().enabled=true;
        veio.GetComponent<EnemyMovement>().followPlayer();
        Destroy(gameObject);
    }
}
