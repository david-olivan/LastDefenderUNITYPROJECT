using UnityEngine;
using System.Collections;

public class SavingAndLoadingController : MonoBehaviour {

    private void OnApplicationQuit () {
        PlayerPrefsManager.Instance.SetEffectsVolume (PlayerPrefsManager.Instance.sfxVolume);
    }
}