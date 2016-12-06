using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (PlayerPrefsManager), typeof (SavingAndLoadingController))]
public class GlobalGameController : MonoBehaviour {

    public static GlobalGameController Instance { get; set; }

    public GameObject notifications;

    private void Start () {
        Instance = this;
        notifications.SetActive (false);
    }

    public void GameOver () {
        notifications.SetActive (true);
        notifications.GetComponentInChildren<Text> ().text = "Game Over!";
        notifications.GetComponentInChildren<Button> ().onClick.AddListener (StartAgain);
        notifications.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = "Play Again";
    }

    public void StartAgain () {
        //Application.LoadLevel (Application.loadedLevel);
        SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }
}