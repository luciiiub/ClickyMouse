using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    public GameManager gameManager; 
    public int difficulty;  //Ajustar en inspector

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);  // Espera a q ocurra un evento para ejecutarse

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);  // Llama al GameManager con dificultad asociada
    }
    
    }
}
