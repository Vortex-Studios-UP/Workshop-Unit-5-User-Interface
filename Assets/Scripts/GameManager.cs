using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; // This is a list of GameObjects that will be used to store the targets

    private float spawnRate = 1.0f; // This is a float that will be used to set the spawn rate of the targets
    private int score; // This is an int that will be used to store the score
    public TextMeshProUGUI scoreText; // This is a TextMeshProUGUI that will be used to display the score

    void Start()
    {
        StartCoroutine(SpawnTarget()); // This will start the SpawnTarget coroutine
        score = 0;
        UpdateScore(score);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; // Increment the score
        scoreText.text = "Score: " + score; // Update the score text
    }

    IEnumerator SpawnTarget()
    {
        while (true) // This will loop forever
        {
            // Wait for spawnRate seconds
            yield return new WaitForSeconds(spawnRate);

            // Get a random index between 0 and the length of the targets list
            int index = Random.Range(0, targets.Count);

            // Instantiate the target at the position of the GameManager
            Instantiate(targets[index]);
        }
    }
}
