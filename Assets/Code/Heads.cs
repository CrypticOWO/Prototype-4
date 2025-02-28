using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class Heads : MonoBehaviour
{
    public Button Button;
    public Button OtherButton;
    public RawImage VideoDisplay;
    public VideoPlayer VideoPlayer;
    public static int Score = 0;
    public TMP_Text ScoreText;

    private void Start()
    {
        VideoDisplay.gameObject.SetActive(false);
        VideoPlayer.gameObject.SetActive(false);
        VideoPlayer.playOnAwake = false;
        VideoPlayer.Stop();
        ScoreText.text = "Correct Guesses:" + Score;
    }

    public void OnButtonClick()
    {
        VideoDisplay.gameObject.SetActive(true);
        VideoPlayer.gameObject.SetActive(true);
        VideoPlayer.Play();
        Button.interactable = false;
        OtherButton.interactable = false;

        Score++;

        VideoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        VideoDisplay.gameObject.SetActive(false);
        VideoPlayer.gameObject.SetActive(false);
        Button.interactable = true;
        OtherButton.interactable = true;

        ScoreText.text = "Correct Guesses:" + Score;
    }
}
