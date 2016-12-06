using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionManager : MonoBehaviour {

    public static ExplosionManager Instance { get; set; }

    public GameObject explosionsPrefab;

    private List<Explosion> spawnedExplosions = new List<Explosion> ();
    private GameObject explosionContainer;

    private void Start () {
        Instance = this;
        explosionContainer = gameObject;
    }
    /*
    private void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Vector3 tempV3 = Camera.main.ScreenToWorldPoint (Input.mousePosition - Camera.main.transform.position);
            Debug.Log (tempV3);
            SpawnExplosion (tempV3);
        }
    }
     */

    /// <summary>
    /// A method that spawns and explosion from an Array.
    /// </summary>
    /// <param name="index">The index of the explosion in the Array.</param>
    /// <param name="position">The position at which to Spawn the explosion.</param>
    public void SpawnExplosion (Vector3 position) {
        Explosion tempExplosion = GetExplosion ();

        tempExplosion.go.transform.position = position;
        tempExplosion.Show (position);
    }
    private Explosion GetExplosion () {
        Explosion tempExp = spawnedExplosions.Find (c => !c.isActive);

        if (tempExp == null) {
            GameObject go = Instantiate (explosionsPrefab) as GameObject;
            tempExp = go.GetComponent<Explosion> ();
            tempExp.go = go;
            tempExp.go.transform.SetParent (explosionContainer.transform);
            spawnedExplosions.Add (tempExp);
        }

        return tempExp;
    }
}