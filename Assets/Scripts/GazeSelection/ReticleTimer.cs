using UnityEngine;
using UnityEngine.UI;

internal class ReticleTimer : MonoBehaviour, IReticle
{
    GameObject radialProgress;
    Image imageRadialProgress;

    [SerializeField]
    float elapsedTime = 0f;
    float loadingTime = 1f;

    private bool isReadyToClick;
    private bool isReticleHovering;

    public bool IsReadyToClick { get => isReadyToClick; set => isReadyToClick = value; }
    public bool IsReticleHovering { get => isReticleHovering; set => isReticleHovering = value; }


    private void Start()
    {
 
        radialProgress = this.transform.GetChild(1).gameObject;
        imageRadialProgress = radialProgress.GetComponent<Image>();
        ResetRadialProgress();

    }

    private void Update()
    {
        
        if (!IsReticleHovering) return;
        elapsedTime += Time.deltaTime;
        UpdateRadialProgress(elapsedTime / loadingTime);

        if (elapsedTime >= loadingTime)
        {
            IsReadyToClick = true;
            ResetRadialProgress();
        }
    }

    public void Reset()
    {
        ResetTimer();
        ResetRadialProgress();
        IsReadyToClick = false;
        IsReticleHovering = false;
    }

    private void ResetTimer()
    {
        elapsedTime = 0f;
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
