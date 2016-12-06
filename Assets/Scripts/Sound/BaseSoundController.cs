using UnityEngine;
using System.Collections;

public class SoundObject
{
    public GameObject sourceGO;
    public Transform sourceTR;

    public AudioClip clip;
    public string name;

    private AudioSource audioSource;

    public SoundObject (AudioClip aClip, string aName, float aVolume, AudioSource source) {
        // In the contructor we create an audio source
        // and store the details of the sound itself
        sourceGO = source.gameObject;
        sourceTR = sourceGO.transform;
        audioSource = source;
        //audioSource.name = "AudioSource_" + aName;
        audioSource.playOnAwake = false;
        audioSource.clip = aClip;
        audioSource.volume = aVolume;
        clip = aClip;
        name = aName;
    }
    /// <summary>
    /// A function to play the SoundObject clip
    /// </summary>
    /// <param name="atPosition">The position at which to play the sound</param>
    public void PlaySound (Vector3 atPosition) {
        sourceTR.position = atPosition;
        audioSource.PlayOneShot (clip);
    }
}
/*
public class BaseSoundController : MonoBehaviour
{
    public static BaseSoundController Instance;

    public AudioClip[] GameSounds;

    private int totalSounds;
    private ArrayList soundObjectList;
    private SoundObject tempSoundObj;

    public float volume = 1;
    public string gamePrefsName = "DefaultGame"; // DO NOT FORGET TO SET THIS IN THE EDITOR!!

    public void Awake () {
        Instance = this;
    }
    private void Start () {
        // We will grab the volume from PlayerPrefs when this script first starts
        volume = PlayerPrefs.GetFloat (gamePrefsName + "_SFXVol");
        Debug.Log ("BaseSoundController gets volume from prefs" + gamePrefsName + "_SFXVol at " + volume);
        soundObjectList = new ArrayList ();

        // Make the sound objects for all the sounds in GameSounds array
        foreach (AudioClip theSound in GameSounds) {
            tempSoundObj = new SoundObject (theSound, theSound.name, volume);
            soundObjectList.Add (tempSoundObj);
            totalSounds++;
        }
    }

    /// <summary>
    /// A function to play a sound using an index and a position
    /// </summary>
    /// <param name="anIndexNumber">Index of the sound to be played</param>
    /// <param name="aPosition">Position at which you want to play the sound</param>
    public void PlaySoundByIndex (int anIndexNumber, Vector3 aPosition) {
        // Make sure we're not trying to play a sound indexed higher than exists in the array
        if (anIndexNumber > soundObjectList.Count) {
            Debug.LogWarning ("BaseSoundController>Trying to do PlaySoundByIndex with invalid index number. Playing last sound in array, instead.");
            anIndexNumber = soundObjectList.Count - 1;
        }

        tempSoundObj = (SoundObject)soundObjectList[anIndexNumber];
        tempSoundObj.PlaySound (aPosition);
    }
}*/