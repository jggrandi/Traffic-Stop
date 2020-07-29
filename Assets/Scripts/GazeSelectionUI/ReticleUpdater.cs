using UnityEngine;
using UnityEngine.UI;

// Updates the position of the reticle (aim).
// The reticle stays at a default distance. 
// If objects are closer than the default distance, the reticle's distance changes to stay always in front of the object.
// Controls when the reticle should appear.


class ReticleUpdater : MonoBehaviour
{
    public GameObject aim;
    private Image aimImage;
    private static float defaultDistance = 1f;
    private UILayerSelector selector;
    private IRayProvider rayProvider;
   
    void Start()
    {
        aimImage = aim.GetComponent<Image>();
        selector = GetComponent<UILayerSelector>();
        // Currently using the VRCameraRayProvider script.
        rayProvider = GetComponent<IRayProvider>();
        
    }

    public void Update()
    {
        // Disables the reticle on the screen.
        DisableReticle();

        Ray ray = rayProvider.CreateRay();
        
        selector.Check(ray);
        //if (selector.GetHit().transform.gameObject == null) return;
        
        // Check if ray casted an desired object.
        if (selector.GetSelection() == null) return;
        
        // Get the shortest distance between default and the current distance.
        float _distance = Mathf.Min(defaultDistance, selector.GetHit().distance);
        // Calculates the updated reticle's distance. 
        Vector3 _reticleDistance = (ray.origin + ray.direction * _distance * 0.9f);

        // Updates the reticle with the calculated position.
        this.transform.position = _reticleDistance;
        this.transform.rotation = Quaternion.LookRotation(this.transform.position - ray.origin);

        // Enables the reticle on the screen.
        EnableReticle();
    }
    void DisableReticle()
    {
        aimImage.enabled = false;
    }

    void EnableReticle()
    {
        aimImage.enabled = true;
    }

}