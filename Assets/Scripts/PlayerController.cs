using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f;
    public float padding = 1.0f;
    //public GameObject gun;
    public GameObject projectile;
    public float projectileSpeed = 5.0f;
    public float startingHealth = 250.0f;
    public float CurrentHealth { get; set; }
    public float touchSpeed = 0.022f;

    private float xmin, xmax;
    private float firingRate = 0.25f;

    private void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
        CurrentHealth = startingHealth;
    }
    private void Update () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            StartFiring ();
        }
        if (Input.GetKeyUp (KeyCode.Space)) {
            StopFiring ();
        }

        if (Input.GetKey (KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {			// Left
            MoveLeft ();
        } else if (Input.GetKey (KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {	// Right
            MoveRight ();
        }

        // Restrict the player to the game space
        float newX = Mathf.Clamp (transform.position.x,xmin,xmax);
        transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
    }

    // TRIGGERS
    private void OnTriggerEnter2D (Collider2D collider) {
        Projectile missile = collider.gameObject.GetComponent<Projectile> ();
        if (missile) {
            CurrentHealth -= missile.GetDamage ();
            missile.Hit ();
            LivesManager.Instance.UpdateLife (CurrentHealth, startingHealth);
            if (CurrentHealth <= 0) {
                LivesManager.Instance.CheckLives ();
            }
        }
    }

    // MOVING methods
    private void MoveLeft () {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private void MoveRight () {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    public void StartMovingLeft () {
        InvokeRepeating ("MoveLeft", 0.000001f, touchSpeed);
    }
    public void StopMovingLeft () {
        CancelInvoke ("MoveLeft");
    }
    public void StartMovingRight () {
        InvokeRepeating ("MoveRight", 0.000001f, touchSpeed);
    }
    public void StopMovingRight () {
        CancelInvoke ("MoveRight");
    }

    // FIRING methods
    private void Fire () {
        Vector3 offset = new Vector3 (0, 1, 0);
        GameObject beam = Instantiate (projectile, transform.position + offset, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, projectileSpeed, 0);
        beam.GetComponent<Projectile> ().MakeNoise ();
    }
    public void StartFiring () {
        InvokeRepeating ("Fire", 0.000001f, firingRate);
    }
    public void StopFiring () {
        CancelInvoke ("Fire");
    }
}