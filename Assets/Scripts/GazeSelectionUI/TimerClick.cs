using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerClick : MonoBehaviour
{
    public bool isReadyToClick { get; set; }
    public bool runTimer = false;
    public float normalizedTime { get; set; }

    float elapsedTime = 0f;
    
    [SerializeField]
    float loadingTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
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
