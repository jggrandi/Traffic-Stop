using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles the timer to confirm clicks.

public class TimerClick : MonoBehaviour
{
    public bool isReadyToClick { get; set; }
    public bool runTimer = false;
    public float normalizedTime { get; set; }

    float elapsedTime = 0f;
    
    [SerializeField]
    float loadingTime = 1f;

    void Start()
    {
        Reset();
    }

    void Update()
    {
        if (!runTimer) return;

        elapsedTime += Time.deltaTime;
        normalizedTime = elapsedTime / loadingTime;

        if (elapsedTime >= loadingTime)
            isReadyToClick = true;
    }

    public void StartRunTimer()
    {
        runTimer = true;
    }

    public void Reset()
    {
        elapsedTime = 0f;
        normalizedTime = 0f;
        isReadyToClick = false;
        runTimer = false;
    }
}
