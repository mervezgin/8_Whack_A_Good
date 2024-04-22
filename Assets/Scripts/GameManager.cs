using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> targets;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button restartGameButton;
    [SerializeField] GameObject TitleScreen;

    Target targetScript;

    public bool isGameActive = false;

    float spawnRate = 1.5f;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartGameButton.gameObject.SetActive(false);
        TitleScreen.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartTheGame(int difficulty)
    {
        UpdateScore(0);
        spawnRate = spawnRate / difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        TitleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartGameButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
