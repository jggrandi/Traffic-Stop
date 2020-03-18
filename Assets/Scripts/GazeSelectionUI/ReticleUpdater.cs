using UnityEngine;
//using Valve.VR.InteractionSystem;

class ReticleUpdater : MonoBehaviour
{
    private static float defaultDistance = 1f;

    private UILayerSelector _selector;
    private IRayProvider _rayProvider;
    void Start()
    {
        _selector = GetComponent<UILayerSelector>();
        _rayProvider = GetComponent<IRayProvider>();
    }

    public void Update()
    {
        Ray ray = _rayProvider.CreateRay();
        _selector.Check(ray);


        if (_selector.GetHit().transform.gameObject == null) return;

        float distance = Mathf.Min(defaultDistance, _selector.GetHit().distance);

        Vector3 reticleDistance = (ray.origin + ray.direction * distance * 0.9f);


        this.transform.position = reticleDistance;
        this.transform.rotation = Quaternion.LookRotation(this.transform.position - ray.origin);
    }
}