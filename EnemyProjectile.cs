using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController player)) {
            player.playerTakeDmg(60);
            Destroy(gameObject);
        } //if (collision.gameObject.TryGetComponent<Bump>(out Bump wall)) {
        //    Destroy(gameObject);
        //} 
    }
}
