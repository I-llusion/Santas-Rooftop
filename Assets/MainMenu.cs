using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1f;
    }

    public void Quitgame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    //Levels
    public void Level01()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1f;
    }
    public void Level02()
    {
        SceneManager.LoadScene("Level02");
        Time.timeScale = 1f;
    }
    public void Level03()
    {
        SceneManager.LoadScene("Level03");
        Time.timeScale = 1f;
    }
    public void Level04()
    {
        SceneManager.LoadScene("Level04");
        Time.timeScale = 1f;
    }
    public void Level05()
    {
        SceneManager.LoadScene("Level05");
        Time.timeScale = 1f;
    }
    public void Level06()
    {
        SceneManager.LoadScene("Level06");
        Time.timeScale = 1f;
    }
}
