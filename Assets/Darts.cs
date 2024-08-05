using UnityEngine;
using UnityEngine.UI;

public class Darts : MonoBehaviour
{
    [SerializeField] private Text scoreText; 
    [SerializeField] private Text resultText; 
    private int score;

    private void Start()
    {
        score = 0;
        UpdateScore();
        resultText.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit by: " + other.tag);
        if (other.CompareTag("Bullet"))
        {
            if (CompareTag("center"))
            {
                score += 10;
            }
            else if (CompareTag("middle"))
            {
                score += 5;
            }
            else if (CompareTag("outer"))
            {
                score += 1;
            }

            UpdateScore();
            Destroy(other.gameObject); 

            CheckScore();
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void CheckScore()
    {
        if (score == 30)
        {
            resultText.text = "You win!";
            ResetGame();
        }
        else if (score > 30)
        {
            resultText.text = "Player lost";
            ResetGame();
        }
    }

    private void ResetGame()
    {
        score = 0;
        
        UpdateScore();
    }
}