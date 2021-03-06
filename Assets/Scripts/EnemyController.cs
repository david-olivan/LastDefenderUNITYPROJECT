﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public GameObject projectile;
    public float health = 150.0f;
    public float projectileSpeed = 10;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 150;

    private ScoreKeeper scoreKeeper;

    private void Start () {
        scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
    }
    private void Update () {
        float probability = Time.deltaTime * shotsPerSecond;
        if (Random.value < probability) { Fire (); }
    }

    private void Fire () {
        Vector3 startPosition = transform.position + new Vector3 (0, -1, 0);
        GameObject missile = Instantiate (projectile, startPosition, Quaternion.identity) as GameObject;
        missile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -projectileSpeed);
        missile.GetComponent<Projectile> ().MakeNoise ();
    }

    private void OnTriggerEnter2D (Collider2D col) {
        Projectile missile = col.gameObject.GetComponent<Projectile> ();
        if (missile) {
            health -= missile.GetDamage ();
            missile.Hit ();

            if (health <= 0) {
                scoreKeeper.UpdateScore (scoreValue);
                Destroy (gameObject);
            }
        }
    }
}