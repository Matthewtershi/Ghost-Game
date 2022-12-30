using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float projectileSpeed;
    public GameObject impactEffect;
    private Rigidbody2D proj;

    // Start is called before the first frame update
    void Start()
    {
        proj = GetComponent<Rigidbody2D>();
        proj.velocity = transform.right * projectileSpeed;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent<BossControl>(out BossControl enemyComponent)) {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            enemyComponent.bossTakeDamage(40);
            Destroy(gameObject);
        } /*if (collision.gameObject.TryGetComponent<BasicEnemyProj>(out BasicEnemyProj proj)) {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        } */
    }
}
