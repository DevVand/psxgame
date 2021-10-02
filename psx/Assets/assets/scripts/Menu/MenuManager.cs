using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;

    public void PlayGame ()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsMenu ()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CreditsMenu ()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void BackMenu ()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void LariURL ()
    {
        Application.OpenURL("https://www.instagram.com/solareh_art/?hl=pt-br");
    }

    public void HaruURL()
    {
        Application.OpenURL("https://linearharu.itch.io/");
    }

    public void LucasURL()
    {
        Application.OpenURL("https://linktr.ee/lucasmorgado");
    }
}
