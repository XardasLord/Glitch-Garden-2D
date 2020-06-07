using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        DontDestroyOnLoad(this);
        _audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
