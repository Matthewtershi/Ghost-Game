using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public int skillCooldown;
    private float nextSkillTime;
    public GameObject cooldownBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;

        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;
        
        transform.position = pos;

        if (Input.GetKeyDown("a")||Input.GetKey(KeyCode.LeftArrow)) {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        } else if (Input.GetKeyDown("d")||Input.GetKey(KeyCode.RightArrow)) {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        } 

        /*if (Input.GetKeyUp(KeyCode.Space)) {
            playerTakeDmg(10);
            //Debug.Log(GameHandler.gameHandler.playerHealth.getHealth());
        } if (Input.GetKeyUp(KeyCode.LeftShift)) {
            playerHeal(10);
            //Debug.Log(GameHandler.gameHandler.playerHealth.getHealth());
        }*/
        
        if (nextSkillTime < Time.time) {
            cooldownBar.transform.localScale = new Vector3(1, 1);
        } else {
            cooldownBar.transform.localScale = new Vector3(0, 1);
        }
        
        if (Input.GetKeyDown("e") && nextSkillTime>Time.time) {
            //Debug.Log("cant");
        } else if (Input.GetKeyDown("e")) {
            playerHeal(20);
            nextSkillTime = Time.time + skillCooldown;
        }
    } 

    public void playerTakeDmg(int amt) {
        GameHandler.gameHandler.playerHealth.Damage(amt);
    }

    public void playerHeal(int amt) {
        GameHandler.gameHandler.playerHealth.Heal(amt);
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void QuitGame() {
        Application.Quit();
    }

}
