using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform StartPos;
    public GameObject Projectile;
    public float shotGap = 1f;
    private float nextShot;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextShot) {
            Instantiate(Projectile, StartPos.position, StartPos.rotation);
            nextShot = Time.time + shotGap;
        }
    }
}
