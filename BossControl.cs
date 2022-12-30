using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossControl : MonoBehaviour
{
    
    public HealthBar healthBar;
    public HealthSystem BossHealth = new HealthSystem(1000);
    public GameObject bullet, homingBullet, StartPos, SweepPos;
    public static float fireRate = 3f;
    public static float burstRate = 4.5f;
    public static float sweepRate = 5f;
    public static float moveRate = 10f;
    private float nextBurstTime, nextFireTime, nextSweep, nextMovement, timer;
    public GameObject WinUI;
    private int stage;
    public SpriteRenderer sprite;
    private List<Color> chosenColors;
    private int times2 = 0;
    private int times3 = 0;

    public void setFireRate(float x) {
        fireRate = x;
    }

    public void setBurstRate(float x) {
        burstRate = x;
    }

    public void setSweepRate(float x) {
        sweepRate = x;
    }

    public void setMoveRate(float x) {
        moveRate = x;
    }

    void Start()
    {
        healthBar.SetUp(BossHealth);
        sprite = GetComponent<SpriteRenderer>();
        chosenColors = new List<Color>();
        chosenColors.Add(Color.white);
        chosenColors.Add(Color.magenta);
        chosenColors.Add(Color.red);
        stage = 1;
    }

    
    void Update()
    {
        /*if (Input.GetKeyUp(KeyCode.Space)) {
            bossTakeDamage(10);
            //Debug.Log(BossHealth.getHealth());
        } if (Input.GetKeyUp(KeyCode.LeftShift)) {
            bossHeal(10);
        }*/

        if (BossHealth.getHealth() == 0) {
            Destroy(gameObject);
            WinUI.SetActive(true);
        }

        if (Time.time > 3) {
            if (nextFireTime < Time.time) {
                Instantiate(homingBullet, StartPos.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }

            if (nextMovement < Time.time) {
                Vector2 pos = transform.position;
                int dir = Random.Range(0, 2);
                int dist = Random.Range(1, 5);
                //Debug.Log(dir + " " + dist);
                if (dir == 1) {
                    dist = -dist;
                } if (pos.y >= 2.5 || pos.y <= -3.5) {
                    if (pos.y >= 2.5) {
                        dist = -dist;
                    } if (pos.y <= -3.5) {
                        dist = Mathf.Abs(dist);
                    }
                }
                pos.y += (float) (3 * dist * 0.1);
                transform.position = pos;
                nextMovement = Time.time + moveRate;
            }
        }
        
        if (stage == 2) {
            sprite.color = chosenColors[stage-1];
            if (times2 == 0) {
                fireRate -= 0.5f;
            }
            if (nextBurstTime < Time.time) {
                wideAttack();
                nextBurstTime = Time.time + burstRate;
            } times2++;
        } if (stage == 3) {
            sprite.color = chosenColors[stage-1];
            if (times3 == 0) {
                fireRate -= 0.5f;
                burstRate -= 1.5f;
            }
            if (nextBurstTime < Time.time) {
                wideAttack();
                nextBurstTime = Time.time + burstRate;
            } if (nextSweep < Time.time) {
                sweep();
                nextSweep = Time.time + sweepRate;
            } times3++;
        }

        if (BossHealth.getHealth()<BossHealth.getmaxHealth()-(int)BossHealth.getmaxHealth()/5) {
            stage = 2;
        } if (BossHealth.getHealth()<BossHealth.getmaxHealth()-(int)BossHealth.getmaxHealth()/2) {
            stage = 3;
        } 
    }

    public void bossTakeDamage(int amt) {
        BossHealth.Damage(amt);
    }

    public void bossHeal(int amt) {
        BossHealth.Heal(amt);
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void wideAttack() {
        Transform start, start2, start3; 
        start = start2 = start3 = StartPos.transform;
        Instantiate(bullet, start.position, start.rotation);
        //Debug.Log("proj 1 has been fired");
        start2.rotation = Quaternion.Euler(0, 0, 13);
        Instantiate(bullet, start2.position, start2.rotation);
        //Debug.Log("proj 2 has been fired");
        start3.rotation = Quaternion.Euler(0, 0, 347);
        Instantiate(bullet, start3.position, start3.rotation);
        //Debug.Log("proj 3 has been fired");
        if (stage == 3) {
            start3.rotation = Quaternion.Euler(0, 0, 26);
            Instantiate(bullet, start3.position, start3.rotation);
            start3.rotation = Quaternion.Euler(0, 0, 334);
            Instantiate(bullet, start3.position, start3.rotation);
        }
        start3.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void sweep() {
        int i;
        Transform start;
        //timer = 0f;
        start = SweepPos.transform;
        for (i = 0; i < 5; i++) {
            //Debug.Log("test");
            Instantiate(bullet, start.position, start.rotation);
            start.position = new Vector2(start.position.x + 2.5f, start.position.y + 2f);
        }
        start.position = new Vector2(start.position.x - (i)*2.5f, start.position.y - (i)*2f);
    }
}
