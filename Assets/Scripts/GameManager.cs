using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    check,
    information,
    inGame,
    win,
    gameOver
}

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameState currentGameState = GameState.check;

    [SerializeField] Canvas informationCanvas = null;
    [SerializeField] Canvas checkCanvas = null;
    [SerializeField] Canvas gameOverCanvas = null;
    [SerializeField] Canvas winCanvas = null;

    public int index = 0;

    private int collectedAnimals = 0;
    private int collectedPoints = 0;

    public int CollectedAnimals { get => collectedAnimals; set => collectedAnimals = value; }
    public int CollectedPoints { get => collectedPoints; set => collectedPoints = value; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetGameState(GameState.inGame);
    }

    public void StartGame()
    {
        //SetGameState(GameState.inGame);

        SceneManager.LoadScene("City");
        
        this.CollectedAnimals = 0;
        this.CollectedPoints = 0;
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
        if (newGameState == GameState.information)
        {
            informationCanvas.enabled = true;
            checkCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            winCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            informationCanvas.enabled = false;
            checkCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            winCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            informationCanvas.enabled = false;
            checkCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            winCanvas.enabled = false;
        }
        else if (newGameState == GameState.check)
        {
            informationCanvas.enabled = false;
            checkCanvas.enabled = true;
            gameOverCanvas.enabled = false;
            winCanvas.enabled = false;
        }
        else if (newGameState == GameState.win)
        {
            informationCanvas.enabled = false;
            checkCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            winCanvas.enabled = true;
        }

        this.currentGameState = newGameState;
    }

    public void CollectAnimals(int animals)
    {
        this.CollectedAnimals += animals;
    }

    public void CollectPoints(int points)
    {
        this.CollectedPoints += points;
    }
}