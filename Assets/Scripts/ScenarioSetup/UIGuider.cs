using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class UIGuider : MonoBehaviour
{

    Player player;
    CanvasGroup partentCanvasGroup;
    public GameObject reticle;

    public static Action OnCheckingVehiclePhase;
    //public static Action OnCheckingDriverPhase;
    //public static Action OnGreetingPhase;
    //public static Action OnAskReasonPhase;

    private static UIGuider _instance;
    public static UIGuider Instance { get { return _instance; } }

    public enum Phases { Intro, Goal, PlateScan, VehicleInfo, Greeting, AskReason, AskDriversLicense, DriverInfo};

    [SerializeField]
    int phase = 0;

    float minAngle = 3f;
    private int currentPhase = -1;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Teleport.instance.CancelTeleportHint();

        player = Player.instance;
        //ShowParentUI();
        HideAllChildUI();
        //reticle.SetActive(false);

        DriverVoiceAnswers.OnAudioFinished += NextPhase;
        HandleInteractableArea.OnEnterInteractableArea += EnableUIDialog;
        HandleInteractableArea.OnExitInteractableArea += DisableUIDialog;
    }

    private void OnDestroy()
    {
        DriverVoiceAnswers.OnAudioFinished -= NextPhase;
        HandleInteractableArea.OnEnterInteractableArea -= EnableUIDialog;
        HandleInteractableArea.OnExitInteractableArea -= DisableUIDialog;
    }

    bool isUIDialogEnabled = false;

    private void EnableUIDialog()
    {
        isUIDialogEnabled = true;
    }

    private void DisableUIDialog()
    {
        isUIDialogEnabled = false;
    }

    //private void ShowParentUI()
    //{
    //    partentCanvasGroup = this.GetComponent<CanvasGroup>();
    //    partentCanvasGroup.alpha = 1f;
    //    partentCanvasGroup.interactable = true;
    //}

    private void HideParentUI()
    {
        partentCanvasGroup = this.GetComponent<CanvasGroup>();
        partentCanvasGroup.alpha = 0f;
        partentCanvasGroup.interactable = false;
    }

    private void HideAllChildUI()
    {
        for (int i = 0; i < this.transform.childCount; i++)
            HideUICanvas(i);
    }

    private void ShowUICanvas(int _id)
    {
        //CanvasGroup cg = this.transform.GetChild(_id).GetComponent<CanvasGroup>();
        //LeanTween.alphaCanvas(cg, 1f, 1f).setEaseInSine();
        //cg.interactable = true;
        //cg.blocksRaycasts = true;
        this.transform.GetChild(_id).gameObject.SetActive(true);
    }

    void HideUICanvas(int _id)
    {
        //CanvasGroup cg = this.transform.GetChild(_id).GetComponent<CanvasGroup>();
        //cg.alpha = 0f;
        //cg.interactable = false;
        //cg.blocksRaycasts = false;        
        this.transform.GetChild(_id).gameObject.SetActive(false);
    }

    Transform previousUITransform;

    private void FaceUITowardsPlayer()
    {
        this.transform.GetChild(phase).position = player.hmdTransform.position + player.hmdTransform.forward;
        this.transform.GetChild(phase).rotation = Quaternion.LookRotation(this.transform.GetChild(phase).position - player.hmdTransform.position);
         
        //this.transform.GetChild(phase).LookAt(new Vector3(player.hmdTransform.position.x, player.hmdTransform.position.y + 180, player.hmdTransform.position.z));
        previousUITransform = this.transform.GetChild(phase);
    }

    private void FaceUIUsingLastTransform()
    {
        this.transform.GetChild(phase).position = previousUITransform.position;
        this.transform.GetChild(phase).rotation = previousUITransform.rotation;
    }


    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(phase);
        if (currentPhase == phase) return;
        HideAllChildUI();
        switch (phase)
        {
            case (int)Phases.Intro:
                {
                    if (Vector3.Angle(player.hmdTransform.position + player.hmdTransform.forward, player.hmdTransform.position + Vector3.forward) < 3f)
                    {
                        //reticle.SetActive(true);
                        ShowUICanvas(phase);
                        FaceUITowardsPlayer();
                        currentPhase = phase;
                        
                    }
                    break;
                }
            case (int)Phases.Goal:
                {
                    //reticle.SetActive(true);
                    ShowUICanvas(phase);
                    FaceUIUsingLastTransform();
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.PlateScan:
                {
                    //reticle.SetActive(true);
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    OnCheckingVehiclePhase();
                    break;
                }
            case (int)Phases.VehicleInfo:
                {
                    //reticle.SetActive(true);
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.Greeting:
                {
                    if (!isUIDialogEnabled) return;
                    //reticle.SetActive(true);
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.AskReason:
                {
                    if (!isUIDialogEnabled) return;
                    //reticle.SetActive(true);
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.AskDriversLicense:
                {
                    if (!isUIDialogEnabled) return;
                    //reticle.SetActive(true);
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    break;
                }
            default:
                break;

        }

    }

    public void HideButton()
    {
        HideAllChildUI();
    }

    public void NextPhase()
    {
        //reticle.SetActive(false);
        phase++;
    }





}
