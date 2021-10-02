using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public void skip ()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("test");
    }
}
