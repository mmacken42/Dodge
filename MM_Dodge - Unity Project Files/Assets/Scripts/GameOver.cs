using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsSurvivedText;
    private bool gameOver;

    private void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }

    private void OnGameOver()
    {
        gameOver = true;

        gameOverScreen.SetActive(true);

        secondsSurvivedText.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
    }

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }
}
