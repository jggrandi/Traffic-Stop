using UnityEngine;
using UnityEngine.UI;

class ProgressUpdater : MonoBehaviour
{
    private TimerClick timerClick;
    Image imageRadialProgress;

    private void Start()
    {
        timerClick = transform.GetComponentInParent<TimerClick>();
        imageRadialProgress = GetComponent<Image>();
        ResetRadialProgress();
    }

    void Update()
    {
        if (!timerClick.runTimer)
        {
            ResetRadialProgress();
            return;
        }
            

        UpdateRadialProgress(timerClick.normalizedTime);

        if (timerClick.isReadyToClick)
            ResetRadialProgress();
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
