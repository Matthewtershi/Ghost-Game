using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyProj : MonoBehaviour
{

    public float projectileSpeed;
    private Rigidbody2D proj;
    // Start is called before the first frame update
    void Start()
    {
        proj = GetComponent<Rigidbody2D>();
        proj.velocity = transform.right * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player)) {
            player.playerTakeDmg(30);
            Destroy(gameObject);
        } //if (collision.gameObject.TryGetComponent<Bump>(out Bump wall)) {
        //    Destroy(gameObject);
        //} 
    }
}
