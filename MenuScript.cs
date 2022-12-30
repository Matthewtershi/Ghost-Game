using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Boss;

    public void Easy() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        BossControl.fireRate = 4f;
        BossControl.burstRate = 5.5f;
        BossControl.sweepRate = 6f;
        BossControl.moveRate = 11f;
        Debug.Log("Easy");
    }

    public void Normal() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Normal");
        
    }

    public void Hard() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        BossControl.fireRate = 2f;
        BossControl.burstRate = 3.5f;
        BossControl.sweepRate = 4f;
        BossControl.moveRate = 9f;
        Debug.Log("Hard");
        
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
