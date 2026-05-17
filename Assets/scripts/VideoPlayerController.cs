using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class VideoPlayerController : MonoBehaviour
{
    [Header("References")]
    public VideoPlayer videoPlayer;
    public Button playPauseButton;
    public TextMeshProUGUI buttonText;

    private bool isPaused = true;

    void Start()
    {
        videoPlayer.Stop();
        isPaused = true;
        UpdateButtonText();
    }

    public void TogglePlayPause()
    {
        if (isPaused)
        {
            videoPlayer.Play();
            isPaused = false;
        }
        else
        {
            videoPlayer.Pause();
            isPaused = true;
        }

        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (buttonText != null)
            buttonText.text = isPaused ? "Play" : "Pause";
    }
}