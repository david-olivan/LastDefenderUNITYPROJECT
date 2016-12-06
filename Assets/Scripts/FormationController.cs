using UnityEngine;

public class FormationController : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10.0f;
    public float height = 5.0f;
    public float speed = 3.5f;
    public float spawnDelay = 0.5f;

    private bool movingRight = true;
    private float xmin, xmax;

    private void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
        xmin = leftBoundary.x;
        xmax = rightBoundary.x;

        SpawnUntilFull ();
    }
    private void Update () {
        transform.position += movingRight ? Vector3.right * speed * Time.deltaTime : Vector3.left * speed * Time.deltaTime;
        
        // Check if formation is going outside the playspace
        float rightEdgeOfFormation = transform.position.x + 0.5f * width;
        float leftEdgeOfFormation = transform.position.x - 0.5f * width;
        if (leftEdgeOfFormation < xmin) {
            movingRight = true;
        } else if (rightEdgeOfFormation > xmax) {
            movingRight = false;
        }

        if (AllMembersDead ()) {
            SpawnUntilFull ();
        }
    }
    private void OnDrawGizmos () {
        Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
    }

    private void SpawnEnemies () {
        foreach (Transform child in transform) {
            GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child.transform;
        }
    }
    private void SpawnUntilFull () {
        Transform freeTransform = NextFreePosition ();
        if (freeTransform) {
            GameObject enemy = Instantiate (enemyPrefab, freeTransform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freeTransform;
        }
        if (NextFreePosition ()) {
            Invoke ("SpawnUntilFull", spawnDelay);
        }
    }
    private Transform NextFreePosition () {
        foreach (Transform child in transform) {
            if (child.childCount == 0) { return child; }
        }
        return null;
    }
    private bool AllMembersDead () {
        foreach (Transform childPositionGameObject in transform) {
            if (childPositionGameObject.childCount > 0) { return false; }
        }
        return true;
    }
}