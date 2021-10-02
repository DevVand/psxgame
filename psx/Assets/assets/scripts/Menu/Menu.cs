using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("context menu:")]
    [SerializeField] Flowchart flow;
    [SerializeField] RectTransform topBar;
    [SerializeField] RectTransform bottomBar;
    [SerializeField] RectTransform topDialogueBar;
    [SerializeField] RectTransform bottomDialogueBar;
    [SerializeField] RectTransform text;
    [Header("variables:")]
    [SerializeField] float contextSmooth = 10;
    public float readTime = 8;
    
    private bool contextMenu = false;
    string lastBlock = "";
    string lastBlockMessage = "";
    string lastBlockDeath = "";

    [Header("tasks menu:")]
    [SerializeField] RectTransform textDialogue;
    [SerializeField] Text tasks;
    [SerializeField] Text tasksTxt;
    [Header("variables:")]
    [SerializeField] float tasksSmooth = 10;
    public int totalDirts = 0;
    public int totalBooks = 0;
    public int totalToilets = 0;
    public int doneDirts = 0;
    public int doneBooks = 0;
    public int doneToilets = 0;
    public bool allDone = false;

    private bool dialogueSystem = false;
    private GameObject player;

    string progressionTxt = "0/10\n\n0/20\n\n2/18";
    private bool tasksMenu = false;

    [Header("fade:")]
    [SerializeField] Image fade;
    private string fadeOutMessage="";
    public float fadeVelocity = .05f;


    [Header("fade:")]
    public int tutorialindex = 0;

    [Header("Crossair")]
    public GameObject crossair;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Interactive");
        foreach (GameObject obj in objects)
        {
            if (obj.GetComponent<Dirty>() != null)
                totalDirts++;
            if (obj.GetComponent<Book>() != null)
                totalBooks++;
            if (obj.GetComponent<Toilet>() != null)
                totalToilets++;
        }
        if (SceneManager.GetActiveScene().name == "test")
        {
            fadeJump(1);
            fadeIn();
        }
        progressionTxt = doneDirts+"/" + totalDirts+"\n\n"+doneBooks+"/"+ totalBooks+"\n\n"+doneToilets+"/"+totalToilets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11)) {
            allDone = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            tasks.text = "test";
            flow.ExecuteBlock("openTasks");
        }
        if (Input.GetButtonDown("Menu"))
        {
            tasksMenu = true;
            tasks.text = progressionTxt;
        }
        if (Input.GetButtonUp("Menu"))
        {
            tasksMenu = false;
        }



        if (tasksMenu)
        {
            tasks.color = Color.Lerp(tasks.color, new Color(tasks.color.r, tasks.color.g, tasks.color.b, 1), Time.deltaTime * tasksSmooth);
            tasksTxt.color = Color.Lerp(tasksTxt.color, new Color(tasksTxt.color.r, tasksTxt.color.g, tasksTxt.color.b, 1), Time.deltaTime * tasksSmooth);
        } else {
            tasks.color = Color.Lerp(tasks.color, new Color(tasks.color.r, tasks.color.g, tasks.color.b, 0), Time.deltaTime * tasksSmooth);
            tasksTxt.color = Color.Lerp(tasksTxt.color, new Color(tasksTxt.color.r, tasksTxt.color.g, tasksTxt.color.b, 0), Time.deltaTime * tasksSmooth);
        }

        //topBar.position = Vector3.Lerp(topBar.position, Vector3.zero, Time.deltaTime * contextSmooth);
        bottomBar.position = Vector3.Lerp(bottomBar.position, Vector3.zero, Time.deltaTime * contextSmooth);
        text.position = Vector3.Lerp(text.position, Vector3.zero, Time.deltaTime * contextSmooth);

        
        if (contextMenu) {
            //topBar.pivot = Vector2.Lerp(topBar.pivot, new Vector2(0, -12.5f), Time.deltaTime * contextSmooth);
            topBar.pivot = Vector2.Lerp(topBar.pivot, new Vector2(0, 1), Time.deltaTime * contextSmooth);
            bottomBar.pivot = Vector2.Lerp(bottomBar.pivot, new Vector2(0, 0), Time.deltaTime * contextSmooth);
            text.pivot = Vector2.Lerp(text.pivot, new Vector2(0, 0), Time.deltaTime * contextSmooth);

            //bottomBar.position = Vector3.Lerp(bottomBar.position, new Vector3(0, 0, 0), Time.deltaTime * smooth);
            //topBar.position = Vector3.Lerp(bottomBar.position, new Vector3(0, 0, 0), Time.deltaTime * smooth);
        }
        else {
            //topBar.pivot = Vector2.Lerp(topBar.pivot, new Vector2(0, -13.5f), Time.deltaTime * contextSmooth);
            topBar.pivot = Vector2.Lerp(topBar.pivot, new Vector2(0, 0), Time.deltaTime * contextSmooth);
            bottomBar.pivot = Vector2.Lerp(bottomBar.pivot, new Vector2(0, 1), Time.deltaTime * contextSmooth);
            text.pivot = Vector2.Lerp(text.pivot, new Vector2(0, 1), Time.deltaTime * contextSmooth);
            //bottomBar.pivot = new Vector2(0, 1);
            //topBar.position = Vector3.Lerp(bottomBar.position, new Vector3(0, 80, 0), Time.deltaTime * smooth);
            //bottomBar.position = Vector3.Lerp(bottomBar.position, new Vector3(0, -80, 0), Time.deltaTime * smooth);
        }

        if (dialogueSystem)
        {
            topDialogueBar.pivot = Vector2.Lerp(topDialogueBar.pivot, new Vector2(0, 1), Time.deltaTime * contextSmooth);
            bottomDialogueBar.pivot = Vector2.Lerp(bottomDialogueBar.pivot, new Vector2(0, 0), Time.deltaTime * contextSmooth);
            textDialogue.pivot = Vector2.Lerp(textDialogue.pivot, new Vector2(0, 0), Time.deltaTime * contextSmooth);
        }
        else
        {
            topDialogueBar.pivot = Vector2.Lerp(topDialogueBar.pivot, new Vector2(0, 0), Time.deltaTime * contextSmooth);
            bottomDialogueBar.pivot = Vector2.Lerp(bottomDialogueBar.pivot, new Vector2(0, 1), Time.deltaTime * contextSmooth);
            textDialogue.pivot = Vector2.Lerp(textDialogue.pivot, new Vector2(0, 1), Time.deltaTime * contextSmooth);
        }

    }

    public void recalculateObjectives() {
        totalBooks+=4; 
        progressionTxt = doneDirts + "/" + totalDirts + "\n\n" + doneBooks + "/" + totalBooks + "\n\n" + doneToilets + "/" + totalToilets;
    }

    public void closeGame() { Application.Quit(); Debug.Log("Fechou"); }
    public void resetScene() { SceneManager.LoadScene("tutorial 0"); }

    public void loadGame() { SceneManager.LoadScene("test"); }
    
    public void loadTutorial() { SceneManager.LoadScene("tutorial"+tutorialindex); }

    public void fadeIn() { StartCoroutine("fadeIn" + "CO"); }

    public void fadeOut(string name){ StartCoroutine("fadeOutCO"); fadeOutMessage=name; }

    public void fadeJump(float to)
    {
        fade.color = new Color(fade.color.r, fade.color.b, fade.color.g, to);
    }

    public void message(string blockName){
        contextMenu = true;
        flow.StopBlock(blockName);
        flow.ExecuteBlock(blockName);
        lastBlockMessage = blockName;
        CancelInvoke(nameof(closeDialog));
        Invoke(nameof(closeDialog), 3);
    }

    public void dialogueMessage(string blockName)
    {
        crossair.SetActive(false);
        player.GetComponent<Pickup>().interactive=false;
        dialogueSystem = true;
        flow.StopBlock(blockName);
        flow.ExecuteBlock(blockName);
    }
    public void deathMessage(string blockName)
    {
        flow.StopBlock(blockName);
        flow.ExecuteBlock(blockName);
        //lastBlockDeath = blockName;
        //Invoke(nameof(closeDeathMessage),3.5f);

    }
    public void closeDeathMessage()
    {
        //flow.StopBlock(lastBlockDeath);
    }


    public void closeDialog() {
        contextMenu = false;
        flow.StopBlock(lastBlockMessage);
    }
    
    public void openDialogueBar()
    {
        dialogueSystem = true;
    }
    public void closeDialogueBar()
    {
        crossair.SetActive(true);
        player.GetComponent<Pickup>().interactive = true;
        player.GetComponent<PlayerMovement>().EnablePlayerMovement();
        dialogueSystem = false;
    }
    public bool updateTaskMenu() {
        progressionTxt = doneDirts + "/" + totalDirts + "\n\n" + doneBooks + "/" + totalBooks + "\n\n" + doneToilets + "/" + totalToilets;
        tasks.text = progressionTxt;
        if (doneDirts == totalDirts && doneBooks == totalBooks && doneToilets == totalToilets)
            return allDone = true;
        return false;
    }

    public void dirtDone() { doneDirts++; updateTaskMenu(); }
    public void bookDone() { doneBooks++; updateTaskMenu(); }
    public void toiletDone() { doneToilets++; updateTaskMenu(); }


    IEnumerator fadeInCO()
    {
        while (true)
        {
            float alpha = fade.color.a;
            alpha -= fadeVelocity/2;
            if (alpha < 0)
            {
                StopCoroutine(nameof(fadeInCO));
            }
            fade.color = new Color(fade.color.r, fade.color.b, fade.color.g, alpha);
            yield return 0.1f;
        }
    }

    IEnumerator fadeOutCO()
    {
        while (true)
        {
            float alpha = fade.color.a;
            alpha += fadeVelocity;
            if (alpha > 1)
            {

                if (fadeOutMessage == "Reset")
                    Invoke(nameof(resetScene), 1);
                else if ((fadeOutMessage == "Game"))
                    Invoke(nameof(loadGame), 1);
                else if ((fadeOutMessage == "tutorial1"))
                    Invoke(nameof(loadTutorial), 1);
                else if ((fadeOutMessage == "FunnyClose"))
                    flow.ExecuteBlock("FunnyClose");
                else if ((fadeOutMessage == "Close"))
                    Invoke(nameof(closeGame), 1);
                StopCoroutine(nameof(fadeOutCO));
            }
            fade.color = new Color(fade.color.r, fade.color.b, fade.color.g, alpha);
            yield return 0.1f;
        }
    }
}
