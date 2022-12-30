using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision) {
        //Debug.Log("contact");
        GameHandler.gameHandler.playerHealth.Damage(5);
    }
}
