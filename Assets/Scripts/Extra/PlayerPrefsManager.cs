using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

    // STRING CONSTANTS for the different entries in PlayerPrefs
    private const string EFFECTS_VOLUME = "SFX_Volume";
    private const string MUSIC_VOLUME = "Music_Volume";

    public static PlayerPrefsManager Instance { get; set; }

    // TODO eliminate variables, only for testing
    public float sfxVolume;
    //public float musicVolume;

    private void Start () {
        Instance = this;
    }

    // TODO eliminate thie function, only for testing
    private void SetPrefsTo () {
        SetEffectsVolume (sfxVolume);
    }

    // METHODS FOR SETTING AND GETTING THE VOLUME (EFFECTS AND MUSIC)
    public void SetMusicVolume (float volume) {
        PlayerPrefs.SetFloat (MUSIC_VOLUME, volume);
    }
    public float GetMusicVolume () {
        return PlayerPrefs.GetFloat (MUSIC_VOLUME);
    }
    public void SetEffectsVolume (float volume) {
        PlayerPrefs.SetFloat (EFFECTS_VOLUME, volume);
    }
    public float GetEffectsVolume () {
        return PlayerPrefs.GetFloat (EFFECTS_VOLUME);
    }
}