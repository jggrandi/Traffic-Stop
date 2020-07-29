using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Minimap loading animation class.
public class MinimapLoad : MinimapListener
{
    public bool isLoad { get; set; }// Trigger to loading animation
    public bool isDeload { get; set; }// Trigger to deloading animation
    public bool loaded; // Whether Minimap is loaded
    private Animator animator;

    void Start()
    {
        InitalSetup();
    }

    protected override void InitalSetup()
    {
        base.InitalSetup();
        isLoad = false;
        isDeload = false;
        loaded = false;
        animator = GetComponent<Animator>();
    }


    protected override void Content(GameObject _candidate)
    {
        loadMap();
    }

    private void loadMap()
    {
        animator.SetBool("Load", isLoad);
        animator.SetBool("Deload", isDeload);
    }

    public void Setloaded()
    {
        loaded = true;
    }

    public void reset()
    {
        loaded = false;
        isLoad = false;
        isDeload = false;
    }

}
