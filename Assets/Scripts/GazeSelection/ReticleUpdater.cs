using UnityEngine;
using Valve.VR.InteractionSystem;

internal class ReticleUpdater : MonoBehaviour
{
    Player player;
    private ISelectionMode selector;
    private GazeSelectionManager selectionManager;
    private static float defaultDistance = 1f;

    void Start()
    {
        player = Player.instance;
        selector = GetComponent<ISelectionMode>();
        selectionManager = GetComponent<GazeSelectionManager>();
    }

    public void Update()
    {


        
        RaycastHit raycastHit;
        
        float hitDistance = defaultDistance;
        if (Physics.Raycast(player.hmdTransform.position, player.hmdTransform.forward, out raycastHit))
            hitDistance = raycastHit.distance;
            
        float distance = Mathf.Min(defaultDistance, hitDistance);

        Vector3 reticleDistance = (player.hmdTransform.position + player.hmdTransform.forward * distance * 0.9f);


        this.transform.position = reticleDistance;
        this.transform.rotation = Quaternion.LookRotation(this.transform.position - player.hmdTransform.position);
    }
}