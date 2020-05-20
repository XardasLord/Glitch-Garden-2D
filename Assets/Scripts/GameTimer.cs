using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in seconds")]
    [SerializeField] private float levelTime = 10;

    private Slider _slider;

    private void Awake() 
        => _slider = GetComponent<Slider>();

    void Update()
    {
        _slider.value = Time.timeSinceLevelLoad / levelTime;

        var levelFinished = Time.timeSinceLevelLoad >= levelTime;

        if (levelFinished)
        {
            Debug.Log("Level timer expired!");
        }
    }
}
