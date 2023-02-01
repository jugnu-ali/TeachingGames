using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        //score
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Your Score: \n" + ScoreKeeper.instance.GetCurrentScore().ToString();
    }

    public void PlayAgain()
    {
        LevelManager.instance.LoadGame();
    }

    public void MainMenu()
    {
        LevelManager.instance.LoadMainMenu();
    }
}
