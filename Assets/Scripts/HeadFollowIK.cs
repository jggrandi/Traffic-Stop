using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HeadFollowIK : MonoBehaviour
{
    Player player;
    Vector3 offset = new Vector3(-.1f, -.4f, -.17f);
    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.hmdTransform.position + offset;
    }
}
