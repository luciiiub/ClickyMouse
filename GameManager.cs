using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;   // Lista de objetos que se van a generar
    public TextMeshProUGUI scoreText;    
    public TextMeshProUGUI gameOverText;   
    public Button restartButton;    // Boton para reiniciar el juego
    public GameObject titleScreen;   // Pantalla inicio

    public bool isGameActive;
    private float spawnRate = 1.0f;    // Tiempo entre aparicion de objetos
    private int score;

    void Start()
    {
      
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate = spawnRate / difficulty;   // Ajusta velocidad segun dificultad!!

        restartButton.gameObject.SetActive(false);  // Oculta el boton 
        gameOverText.gameObject.SetActive(false);  // Oculta el texto 
        titleScreen.SetActive(false);   // Oculta la pantalla de inicio

        StartCoroutine(SpawnTarget());  // Genera objetos
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);  // Genera un objeto aleatorio
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;  // Actualiza el texto
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // Muestra texto 
        restartButton.gameObject.SetActive(true);   // Muestra boton 
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia escena
    }
}
