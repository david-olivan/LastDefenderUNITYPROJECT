using UnityEngine;

public class Explosion : MonoBehaviour
{    
    public bool isActive;
    public GameObject go;

    private SoundObject soundObject;
    private AudioSource audioSource;

    public void Show (Vector3 position) {
        isActive = true;
        go.SetActive (true);
        PlaySound (position);
    }
    public void PlaySound (Vector3 position) {
        audioSource = GetComponent<AudioSource> ();
        if (soundObject == null) {
            soundObject = new SoundObject (audioSource.clip, "ExplosionSound", PlayerPrefsManager.Instance.GetEffectsVolume (), audioSource);
        }
        soundObject.PlaySound (position);
    }
    public void Hide () {
        isActive = false;
        go.SetActive (false);
    }
}