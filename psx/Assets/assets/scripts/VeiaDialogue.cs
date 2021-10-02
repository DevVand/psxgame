using UnityEngine;
using Fungus;
using System.Collections;

public class VeiaDialogue : MonoBehaviour
{
    public Transform target;
    private Menu menu;
    public PlayerMovement move;
    public PlayerCamera camera;
    private bool interacted = false;

    private void Start()
    {
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!interacted && other.gameObject.CompareTag("Player"))
        {
            menu.dialogueMessage("veiaDialogue");
            move.DisablePlayerMovement();
            camera.lookAt(target);
            interacted = true;
        }
    }
}
