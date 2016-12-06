using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneBar : MonoBehaviour {

    public Slider progressBar;
    public Text progressText;
    
	void Start () {
        LoadLevel ();
	}

    public void LoadLevel () {
        progressBar.gameObject.SetActive (true);
        progressText.gameObject.SetActive (true);
        progressText.text = "Loading...";
        StartCoroutine (LoadLevelWithProgress ());
    }

    IEnumerator LoadLevelWithProgress () {
        yield return new WaitForSeconds (1);

        AsyncOperation ao = SceneManager.LoadSceneAsync (1);
        ao.allowSceneActivation = false;

        while (!ao.isDone) {
            progressBar.value = ao.progress;

            if (ao.progress == 0.9f) {
                progressBar.value = 1.0f;
                progressText.text = "Press 'Space' to continue";
                if (Input.GetKeyDown(KeyCode.Space)) {
                    ao.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
}