using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in seconds")]
    [SerializeField] private float levelTime = 10;

    private Slider _slider;
    private bool _timerExpired;
    public static event Action OnExpired = delegate { };

    private void Awake() 
        => _slider = GetComponent<Slider>();

    private void Update()
    {
        if (_timerExpired)
            return;
        
        _slider.value = Time.timeSinceLevelLoad / levelTime;

        var levelFinished = Time.timeSinceLevelLoad >= levelTime;

        if (levelFinished)
        {
            OnExpired();
            _timerExpired = true;
        }
    }
}
