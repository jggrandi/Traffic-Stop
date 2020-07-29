using UnityEngine;
using UnityEngine.UI;

// Fills the UI circular progress bar based on the timer to click.

class ProgressUpdater : MonoBehaviour
{
    private Timer timerClick;
    Image imageRadialProgress;
    public bool reverseUpdate { get; set; }

    private void Start()
    {
        timerClick = transform.GetComponentInParent<Timer>();
        imageRadialProgress = GetComponent<Image>();
        ResetRadialProgress();
        reverseUpdate = false;
    }

    void Update()
    {
        if (!timerClick.RunTimer)
        {
            ResetRadialProgress();
            return;
        }

        if (!reverseUpdate)
        {
            UpdateRadialProgress(timerClick.NormalizedTime);
        }
        else
        {
            UpdateRadialProgress(1- timerClick.NormalizedTime);
        }

        if (timerClick.TimeIsUp)
        {
            ResetRadialProgress();
        }

    }

    public void ResetRadialProgress()
    {
        imageRadialProgress.fillAmount = 0f;
    }

    public void UpdateRadialProgress(float _value)
    {
        imageRadialProgress.fillAmount = _value;
    }

}
