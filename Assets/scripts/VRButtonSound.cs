using UnityEngine;

#if UNITY_XR_INTERACTION_TOOLKIT
using UnityEngine.XR.Interaction.Toolkit;
#endif

[RequireComponent(typeof(AudioSource))]
public class VRButtonSound : MonoBehaviour
{
    public AudioClip clip;

    private AudioSource _audio;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = clip;
        _audio.loop = true;
        _audio.spatialBlend = 1f;
        _audio.playOnAwake = false;

#if UNITY_XR_INTERACTION_TOOLKIT
        var interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
            interactable.selectEntered.AddListener(_ => Toggle());
#endif
    }

    // Called by XR Interaction Toolkit, Physics trigger, or directly from code / UnityEvent
    public void Toggle()
    {
        if (_audio.isPlaying) _audio.Stop();
        else _audio.Play();
    }

    // Physics / trigger collider fallback
    void OnTriggerEnter(Collider other) => Toggle();
}
