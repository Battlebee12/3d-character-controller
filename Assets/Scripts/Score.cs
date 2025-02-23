using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;             // Current score
    public TMP_Text scoreText;        // Reference to the TextMeshPro UI element

    void Start()
    {
        // Initialize the score display
        UpdateScore();
    }

    // This method is called when the player's collider enters a trigger collider
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        // Check if the collided object has the "Coin" tag
        if (other.CompareTag("Coin"))
        {
            // Increase the score and update the UI
            score++;
            UpdateScore();

            // Destroy the coin object
            Destroy(other.gameObject);
        }
    }

    // Updates the TMP text to reflect the current score
    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
