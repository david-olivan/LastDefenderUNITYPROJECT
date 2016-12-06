using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public int score;

    private Text myText;

    private void Start () {
        myText = GetComponent<Text> ();
        Reset ();
    }

    public void UpdateScore (int points) {
        score += points;
        myText.text = score.ToString ();
    }
    private void Reset () {
        score = 0;
        myText.text = score.ToString ();
    }
}