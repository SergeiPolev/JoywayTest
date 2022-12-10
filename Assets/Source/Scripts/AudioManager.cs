using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundsLibrary soundsLibrary;

    public SoundsLibrary SoundsLibrary => soundsLibrary;

    public static AudioManager _instance;

    private const string MUTE = "Mute";

    private void Awake()
    {
        _instance = this;

        audioSource.volume = PlayerPrefs.GetFloat(MUTE, 1f);
    }

    public void PlayOneShot(AudioClip clip, float volume = 1f)
    {
        /// Deleted Volume feature to fix sounds volume on .5f;

        audioSource.PlayOneShot(clip, .5f);
    }

    public void Mute()
    {
        var volume = PlayerPrefs.GetFloat(MUTE, 1f);
        PlayerPrefs.SetFloat(MUTE, volume == 1f ? 0 : 1f);
        audioSource.volume = PlayerPrefs.GetFloat(MUTE, 1f);
    }
}