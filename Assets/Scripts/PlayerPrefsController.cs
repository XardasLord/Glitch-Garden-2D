using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MasterVolumeKey = "master volume";
    private const string DifficultyKey = "difficulty";

    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;

    private const float MinDifficulty = 0f;
    private const float MaxDifficulty = 2f;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MinVolume && volume <= MaxVolume)
        {
            PlayerPrefs.SetFloat(MasterVolumeKey, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range.");
        }
    }

    public static float GetMasterVolume()
        => PlayerPrefs.GetFloat(MasterVolumeKey);

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MinDifficulty && difficulty <= MaxDifficulty)
        {
            PlayerPrefs.SetFloat(DifficultyKey, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty value is out of range.");
        }
    }

    public static float GetDifficulty()
        => PlayerPrefs.GetFloat(DifficultyKey);
}
