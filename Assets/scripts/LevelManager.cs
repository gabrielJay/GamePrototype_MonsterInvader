using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("multiplayer");
    }
    public void StartGame1()
    {
        SceneManager.LoadScene("singleplayer");
    }

    public void doExitGame()
    {
        SceneManager.LoadScene("GameStart");

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("multiplayer");
        }
        if (Input.GetKey(KeyCode.N))
        {
            SceneManager.LoadScene("singleplayer");
        }
    }
}
