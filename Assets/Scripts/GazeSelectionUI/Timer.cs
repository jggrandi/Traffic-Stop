using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles a timer 

public class Timer : MonoBehaviour
{
    public bool TimeIsUp { get; set; }
    public float NormalizedTime { get; set; }
    public bool RunTimer { get; set; } = false;
    public float TimeLimit { get; set; } = 1f;

    public float elapsedTime = 0f;

    void Start()
    {
        Reset();
    }

    void FixedUpdate()
    {
        if (!RunTimer) return;

        elapsedTime += Time.deltaTime;
        NormalizedTime = elapsedTime / TimeLimit;

        if (elapsedTime >= TimeLimit)
            TimeIsUp = true;
    }

    public void StartRunTimer()
    {
        RunTimer = true;
    }

    public void Reset()
    {
        elapsedTime = 0f;
        NormalizedTime = 0f;
        TimeIsUp = false;
        RunTimer = false;
    }
}
