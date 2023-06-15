using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

}