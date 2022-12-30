using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public static GameHandler gameHandler { get; private set; }
    public HealthBar healthBar;
    public HealthSystem playerHealth= new HealthSystem(100);
    public GameObject gameOverUI;

    void Awake()
    {
        if (gameHandler != null && gameHandler != this) {
            Destroy(this);
        } else {
            gameHandler = this;
        }

        healthBar.SetUp(playerHealth);
    }

    void Update() {
        if (playerHealth.getHealth() == 0) {
            playerHealth.setHealth(120);
            Destroy(gameObject);
            gameOverUI.SetActive(true);
        }
    }

    private void gameOver() {
        gameOverUI.SetActive(true);
    }

    public void restart() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
        
    }
}
