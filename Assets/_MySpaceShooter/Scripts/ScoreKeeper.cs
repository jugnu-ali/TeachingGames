using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int currentScore = 0;

    public static ScoreKeeper instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void SetCurrentScore(int amount)
    {
        currentScore += amount;

        Mathf.Clamp(currentScore, 0, int.MaxValue);

        Debug.Log(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
