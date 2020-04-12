using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOver;
    public bool isGameOver;
    public GameObject spawner;
    public float time { get; private set; }

    
    void Awake()
    {//Singleton Pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;            
        }    
    }



    // Start is called before the first frame update
    void Start()
    {//Initialize the Game
        isGameOver = false;
        time = 0;

    }

    public void EndGame()
    {//Stop Game & Time. Transition to gameOver panel
        isGameOver = true;
        gameOver.SetActive(true);
        time = 0f;
        Time.timeScale = 0;
    }


    public void StartEasyGame()
    {//Easy Mode
        Spawner.waitTime = 0.6f;
        EnemyMovement.speed = 6f;
        StartGame();
    }

    public void StartNormalGame()
    {//Normal Mode
        Spawner.waitTime = 0.55f;
        EnemyMovement.speed = 8f;
        StartGame();
    }


    public void StartHardGame()
    {//Hard Mode
        Spawner.waitTime = 0.40f;
        EnemyMovement.speed = 10f;
        StartGame();
    }


    public void StartGame()
    {//Initialize default game state & Load game. Resume time if needed
        isGameOver = false;
        SceneManager.LoadScene("Game");
        time = 0;
        Time.timeScale = 1;
    }

    
    public void ExitGame()
    {//Close the application        
        Application.Quit();
    }

    
    public void Settings()
    {//Loads Settings
        SceneManager.LoadScene("Settings");
    }

    public void About()
    {//Load About Info.
        SceneManager.LoadScene("About");
    }

    public void StartMenu()
    {//Load main menu
        SceneManager.LoadScene("Main");
    }


    // Update is called once per frame
    void Update()
    {//Listen for request for close app and main menu. 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartMenu();
        }
        if (isGameOver)
        {//Save high score if game ends
            Score.instance.SaveHighScore();
        }
        time += Time.deltaTime;

    }
}
