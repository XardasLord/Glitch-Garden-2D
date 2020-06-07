using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private float defaultVolume = 0.8f;

    [SerializeField] private Slider difficultySlider;
    [SerializeField] private float defaultDifficulty = 0f;

    private MusicPlayer _musicPlayer;

    private void Awake()
    {
        _musicPlayer = FindObjectOfType<MusicPlayer>();
        if (!_musicPlayer)
        {
            Debug.LogWarning("No music player was found...");
        }
    }

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        if (_musicPlayer)
        {
            _musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);

        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
