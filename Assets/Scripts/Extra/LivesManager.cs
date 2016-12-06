using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {

    public static LivesManager Instance { get; set; }

    public int lives;
    public GameObject notifications;
    public Image[] livesSprites;

    private float theTimeScale;

    private void Start () {
        Instance = this;
    }

    public void CheckLives () {
        theTimeScale = Time.timeScale;
        GameObject go = GameObject.FindGameObjectWithTag ("Player");
        Time.timeScale = 0;
        lives -= 1;
        //livesSprites[lives].fillAmount = 1.0f;
        livesSprites[lives].color = Color.black;

        if (lives <= 0) {
            GlobalGameController.Instance.GameOver ();
            Destroy (go);
        } else {
            // Take one live away
            go.GetComponent<PlayerController> ().CurrentHealth = go.GetComponent<PlayerController> ().startingHealth;
            notifications.SetActive (true);
            notifications.GetComponentInChildren<Text> ().text = "You Lost One Life :(";
            notifications.GetComponentInChildren<Button> ().onClick.AddListener (CloseNotifications);
            notifications.GetComponentInChildren<Button> ().GetComponentInChildren<Text> ().text = "Keep Playing!";
        }
    }

    private void CloseNotifications () {
        notifications.SetActive (false);
        Time.timeScale = theTimeScale;
    }

    public void UpdateLife (float currentHealth, float maxValue) {
        float temp = NormalizeValue (currentHealth, maxValue);
        livesSprites[lives - 1].fillAmount = temp;
    }

    private float NormalizeValue (float value, float max) {
        float normalizedValue = value / max;
        return normalizedValue;
    }
}