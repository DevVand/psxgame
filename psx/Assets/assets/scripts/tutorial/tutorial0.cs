using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class tutorial0 : MonoBehaviour
{
    private GameObject player; private Menu menu;
    [SerializeField] PlayerCamera camera;
    [SerializeField] Flowchart flow;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().DisablePlayerMovement();
        camera.disableMovement();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Menu>();
        menu.fadeJump(1);
        flow.ExecuteBlock("tutorial0");

    }

    public void finished() {
        menu.fadeOut("tutorial1");
        menu.tutorialindex = 1;
    }


}
