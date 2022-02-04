using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Level_01";

    // Start is called before the first frame update
    public void startGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
