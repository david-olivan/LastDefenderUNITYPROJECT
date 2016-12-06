using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float damage = 100.0f;

    private AudioSource audioSource;
    private SoundObject laserSound;

    public float GetDamage () {
        return damage;
    }
    public void Hit () {
        ExplosionManager.Instance.SpawnExplosion (transform.position);
        Destroy (gameObject);
    }
    public void MakeNoise () {
        audioSource = GetComponent<AudioSource> ();
        laserSound = new SoundObject (audioSource.clip, "LaserSound", PlayerPrefsManager.Instance.GetEffectsVolume (), audioSource);
        laserSound.PlaySound (transform.position);
    }
}