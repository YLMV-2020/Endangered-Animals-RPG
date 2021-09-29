using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    menu,
    points,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    public GameState currentGameState = GameState.menu;

    [SerializeField] Canvas menuCanvas = null;
    [SerializeField] Canvas gameCanvas = null;
    [SerializeField] Canvas gameOverCanvas = null;

    private int collectedMoney = 0;
    private int collectedPoints = 0;

    public int CollectedMoney { get => collectedMoney; set => collectedMoney = value; }
    public int CollectedPoints { get => collectedPoints; set => collectedPoints = value; }

    private void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        //BackToMenu();
    }

    void Update()
    {

    }

    public void StartGame()
    {
        //SetGameState(GameState.inGame);

        SceneManager.LoadSceneAsync("City");
        
        this.CollectedMoney = 0;
        this.CollectedPoints = 0;
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            gameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            gameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }

        this.currentGameState = newGameState;
    }

    public void CollectMoney(int money)
    {
        this.CollectedMoney += money;
    }

    public void CollectPoints(int points)
    {
        this.CollectedPoints += points;
    }
}